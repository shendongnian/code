    Private mUsings As New HashSet(Of String)
    Sub InitializeAllMembers()
        Try
            Dim assignmentPattern As New Regex("(?<Indent>\s*)(?:(?<DeclaredType>\S+)\s+)?(?<VariableName>[\S=]+)\s*=\s*(?<new>new)?\s*(?<CreatedType>[^\s\(]+)")
            Dim selection As EnvDTE.TextSelection = CType(DTE.ActiveDocument.Selection(), EnvDTE.TextSelection)
            Dim editPoint As EditPoint = selection.BottomPoint.CreateEditPoint
            ' Get info from current line in editor
            editPoint.StartOfLine()
            Dim match As Match = assignmentPattern.Match(editPoint.GetText(editPoint.LineLength))
            If Not match.Success Then
                MessageBox.Show("No assignment on row")
                Exit Sub
            End If
            Dim foundDeclaredType As Boolean = match.Groups("DeclaredType").Success AndAlso match.Groups("DeclaredType").Value <> "var"
            Dim foundCreatedType As Boolean = match.Groups("new").Success
            If Not (foundDeclaredType OrElse foundCreatedType) Then
                MessageBox.Show("Can't find type on row")
                Exit Sub
            End If
            Dim typeToExpand As String = If(foundDeclaredType, match.Groups("DeclaredType"), match.Groups("CreatedType")).Value
            ' Traverse upwards in current file and record all using statements
            Dim currentFunction As CodeElement = FindCodeElement(selection.ActivePoint, DTE.ActiveDocument.ProjectItem.FileCodeModel.CodeElements)
            If currentFunction Is Nothing Then
                MessageBox.Show("Can't find current function")
                Exit Sub
            End If
            mUsings.Clear()
            FindAllUsings(currentFunction)
            ' Loop all projects in solution to find requested type
            Dim classType As CodeElement = DTE.Solution.Projects.Cast(Of Project) _
                                                                .Select(Function(x) FindClassInProjectItems(x.ProjectItems, typeToExpand)) _
                                                                .FirstOrDefault(Function(x) x IsNot Nothing)
            If classType Is Nothing Then
                MessageBox.Show("Can't find type in solution: " & typeToExpand)
                Exit Sub
            End If
            PrintMemberAssignments(editPoint, match.Groups("Indent").Value & match.Groups("VariableName").Value, GetMembers(classType))
        Catch objException As System.Exception
            MessageBox.Show(objException.Message)
        End Try
    End Sub
    ' Records all using statements active for a codeelement
    Sub FindAllUsings(ByVal elem As Object)
        If TypeOf elem Is CodeFunction Then
            FindAllUsings(CType(elem, CodeFunction).Parent)
        ElseIf TypeOf elem Is CodeClass Then
            mUsings.Add(CType(elem, CodeClass).FullName)
            FindAllUsings(CType(elem, CodeClass).Parent)
        ElseIf TypeOf elem Is CodeStruct Then
            mUsings.Add(CType(elem, CodeStruct).FullName)
            FindAllUsings(CType(elem, CodeStruct).Parent)
        ElseIf TypeOf elem Is CodeNamespace Then
            mUsings.Add(CType(elem, CodeNamespace).FullName)
            For Each ns As String In CType(elem, CodeNamespace).Members.OfType(Of CodeImport) _
                                                                       .Select(Function(x) x.Namespace)
                mUsings.Add(ns)
            Next
            FindAllUsings(CType(elem, CodeNamespace).Parent)
        ElseIf TypeOf elem Is FileCodeModel Then
            For Each ns As String In CType(elem, FileCodeModel).CodeElements.OfType(Of CodeImport) _
                                                                            .Select(Function(x) x.Namespace)
                mUsings.Add(ns)
            Next
        End If
    End Sub
    ' Find code element (i.e. function) for current line
    Public Function FindCodeElement(ByVal caretPosition As TextPoint, ByVal elems As CodeElements) As CodeElement
        If elems Is Nothing Then Return Nothing
        Return elems.Cast(Of CodeElement) _
                    .Where(Function(x) x.StartPoint.LessThan(caretPosition) AndAlso _
                                       x.EndPoint.GreaterThan(caretPosition)) _
                    .Select(Function(x) If(FindCodeElement(caretPosition, GetMembers(x)), x)) _
                    .FirstOrDefault()
    End Function
    Public Sub PrintMemberAssignments(ByVal editPoint As EditPoint, ByVal prefix As String, ByVal members As CodeElements)
        For Each member As CodeElement In members
            Dim text As String
            If TypeOf member Is CodeProperty Then
                If CType(member, CodeProperty).Setter Is Nothing Then Continue For
                If CType(member, CodeProperty).Setter.Access <> vsCMAccess.vsCMAccessPublic Then Continue For
                If CType(member, CodeProperty).Setter.IsShared Then Continue For
                text = MemberAssignment(prefix, member.Name, CType(member, CodeProperty).Type)
            ElseIf TypeOf member Is CodeVariable Then
                If CType(member, CodeVariable).Access <> vsCMAccess.vsCMAccessPublic Then Continue For
                If CType(member, CodeVariable).IsConstant Then Continue For
                If CType(member, CodeVariable).IsShared Then Continue For
                text = MemberAssignment(prefix, member.Name, CType(member, CodeVariable).Type)
            Else
                Continue For
            End If
            editPoint.EndOfLine()
            editPoint.Insert(ControlChars.NewLine)
            editPoint.Insert(text)
        Next
    End Sub
    Private Function MemberAssignment(ByVal prefix As String, ByVal membername As String, ByVal typeref As EnvDTE.CodeTypeRef) As String
        Dim typekind As EnvDTE.vsCMTypeRef = typeref.TypeKind
        Dim value As String
        If typekind = vsCMTypeRef.vsCMTypeRefArray Then
            value = "{0}.{1} = new {2}[1];"
            If typeref.ElementType.TypeKind = vsCMTypeRef.vsCMTypeRefCodeType Then
                value = value & ControlChars.NewLine & "{0}.{1}[0] = new {2}();"
            End If
            Return String.Format(value, prefix, membername, TrimKnownNamespace(typeref.ElementType.AsString))
        ElseIf typekind = vsCMTypeRef.vsCMTypeRefBool Then
            value = "false"
        ElseIf typekind = vsCMTypeRef.vsCMTypeRefChar Then
            value = "'x'"
        ElseIf typekind = vsCMTypeRef.vsCMTypeRefDecimal Then
            value = "0.00m"
        ElseIf typekind = vsCMTypeRef.vsCMTypeRefDouble Then
            value = "0.00"
        ElseIf typekind = vsCMTypeRef.vsCMTypeRefInt Then
            value = "0"
        ElseIf typekind = vsCMTypeRef.vsCMTypeRefLong Then
            value = "0"
        ElseIf typekind = vsCMTypeRef.vsCMTypeRefShort Then
            value = "0"
        ElseIf typekind = vsCMTypeRef.vsCMTypeRefByte Then
            value = "0"
        ElseIf typekind = vsCMTypeRef.vsCMTypeRefString Then
            value = """" & membername & """"
        ElseIf typekind = vsCMTypeRef.vsCMTypeRefArray Then
            value = "new " & TrimKnownNamespace(typeref.ElementType.AsString) & "[1]"
        ElseIf typekind = vsCMTypeRef.vsCMTypeRefCodeType AndAlso _
                typeref.AsString = "System.DateTime" Then
            value = String.Format("new DateTime({0:yyyy},{0:%M},{0:%d})", DateTime.Today)
        Else
            value = "new " & TrimKnownNamespace(typeref.AsString) & "()"
        End If
        Return String.Format("{0}.{1} = {2};", prefix, membername, value)
    End Function
    Private Function TrimKnownNamespace(ByVal fullName As String) As String
        Return fullName.Substring(mUsings.Where(Function(x) fullName.StartsWith(x) AndAlso _
                                                            fullName.Length > x.Length AndAlso _
                                                            fullName(x.Length) = "."c) _
                                         .Select(Function(x) x.Length + 1) _
                                         .DefaultIfEmpty(0) _
                                         .Max())
    End Function
    Private Function FindClassInProjectItems(ByVal nprojectItems As ProjectItems, ByVal classname As String) As CodeElement
        If nprojectItems Is Nothing Then Return Nothing
        For Each nprojectitem As ProjectItem In nprojectItems
            Dim found As CodeElement
            If nprojectitem.Kind = EnvDTE.Constants.vsProjectItemKindPhysicalFile Then
                If nprojectitem.FileCodeModel Is Nothing Then Continue For
                found = FindClassInCodeElements(nprojectitem.FileCodeModel.CodeElements, classname)
                If found IsNot Nothing Then Return found
            End If
            If nprojectitem.SubProject IsNot Nothing Then
                found = FindClassInProjectItems(nprojectitem.SubProject.ProjectItems, classname)
                If found IsNot Nothing Then Return found
            End If
            found = FindClassInProjectItems(nprojectitem.ProjectItems, classname)
            If found IsNot Nothing Then Return found
        Next
    End Function
    Private Function FindClassInCodeElements(ByVal elems As CodeElements, ByVal classname As String) As CodeElement
        If elems Is Nothing Then Return Nothing
        For Each elem As CodeElement In elems
            If IsClassType(elem) Then
                If classname = elem.Name Then Return elem
            ElseIf Not TypeOf elem Is CodeNamespace Then
                Continue For
            End If
            If mUsings.Contains(elem.FullName) Then
                Dim found As CodeElement = FindClassInCodeElements(GetMembers(elem), classname)
                If found IsNot Nothing Then Return found
            End If
        Next
        Return Nothing
    End Function
    Private Function GetMembers(ByVal elem As CodeElement) As CodeElements
        If TypeOf elem Is CodeClass Then
            Return CType(elem, CodeClass).Members
        ElseIf TypeOf elem Is CodeNamespace Then
            Return CType(elem, CodeNamespace).Members
        ElseIf TypeOf elem Is CodeStruct Then
            Return CType(elem, CodeStruct).Members
        ElseIf TypeOf elem Is CodeInterface Then
            Return CType(elem, CodeInterface).Members
        End If
        Return Nothing
    End Function
    Private Function IsClassType(ByVal elem As CodeElement) As Boolean
        Return TypeOf elem Is CodeClass OrElse TypeOf elem Is CodeStruct OrElse TypeOf elem Is CodeInterface
    End Function
