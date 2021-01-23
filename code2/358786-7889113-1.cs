    'Option Strict Off
    'Option Explicit Off
    Imports EnvDTE
    Imports EnvDTE80
    Imports System.Diagnostics
    Imports Microsoft.VisualBasic
    Imports Microsoft.VisualBasic.ControlChars
    Imports System.Windows.Forms
    Imports Microsoft.VisualStudio.VCCodeModel
    Imports Microsoft.VisualStudio.VCProjectEngine
    Public Module Module1
    Sub Macro2()
        Dim objTextDocument As EnvDTE.TextDocument
        Dim objCursorTextPoint As EnvDTE.TextPoint
        Try
            objTextDocument = CType(DTE.ActiveDocument.Object, EnvDTE.TextDocument)
            objCursorTextPoint = objTextDocument.Selection.ActivePoint()
            objTextDocument.Selection.LineUp()
            objTextDocument.Selection.SelectLine()
            If objTextDocument.Selection.Text.Contains("*/") Then
                objTextDocument.Selection.LineUp()
                objTextDocument.Selection.LineDown()
                objTextDocument.Selection.NewLine()
                objTextDocument.Selection.LineUp()
                objTextDocument.Selection.Insert("Released", vsInsertFlags.vsInsertFlagsInsertAtStart)
            End If
            MsgBox(objTextDocument.Selection.Text)
        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Macro1()
        Dim objCodeElement As EnvDTE.CodeElement
        Dim objCursorTextPoint As EnvDTE.TextPoint
        Try
            objCursorTextPoint = GetCursorTextPoint()
            If Not (objCursorTextPoint Is Nothing) Then
                For i As Integer = 0 To 39
                    objCodeElement = objCursorTextPoint.CodeElement(i)
                    If Not objCodeElement Is Nothing Then
                        MsgBox("wow, we have something: " & objCodeElement.FullName)
                    End If
                Next i
                If objCodeElement Is Nothing Then
                    MsgBox("Visual studio is a joke")
                End If
            End If
        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub GetCodeElementAtCursor()
        Dim objCodeElement As EnvDTE.CodeElement
        Dim objCursorTextPoint As EnvDTE.TextPoint
        Try
            objCursorTextPoint = GetCursorTextPoint()
            If Not (objCursorTextPoint Is Nothing) Then
                ' Get the class at the cursor
                objCodeElement = GetCodeElementAtTextPoint(vsCMElement.vsCMElementFunction, _
                   DTE.ActiveDocument.ProjectItem.FileCodeModel.CodeElements, objCursorTextPoint)
            End If
            If objCodeElement Is Nothing Then
                MessageBox.Show("No class found at the cursor!")
            Else
                MessageBox.Show("Class at the cursor: " & objCodeElement.FullName)
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Function GetCursorTextPoint() As EnvDTE.TextPoint
        Dim objTextDocument As EnvDTE.TextDocument
        Dim objCursorTextPoint As EnvDTE.TextPoint
        Try
            objTextDocument = CType(DTE.ActiveDocument.Object, EnvDTE.TextDocument)
            objCursorTextPoint = objTextDocument.Selection.ActivePoint()
        Catch ex As System.Exception
        End Try
        Return objCursorTextPoint
    End Function
    Private Function GetCodeElementAtTextPoint(ByVal eRequestedCodeElementKind As EnvDTE.vsCMElement, _
       ByVal colCodeElements As EnvDTE.CodeElements, ByVal objTextPoint As EnvDTE.TextPoint) _
       As EnvDTE.CodeElement
        Dim objCodeElement As EnvDTE.CodeElement
        Dim objResultCodeElement As EnvDTE.CodeElement
        Dim colCodeElementMembers As EnvDTE.CodeElements
        Dim objMemberCodeElement As EnvDTE.CodeElement
        If Not (colCodeElements Is Nothing) Then
            For Each objCodeElement In colCodeElements
                If objCodeElement.StartPoint.GreaterThan(objTextPoint) Then
                    ' The code element starts beyond the point
                ElseIf objCodeElement.EndPoint.LessThan(objTextPoint) Then
                    ' The code element ends before the point
                Else ' The code element contains the point
                    If objCodeElement.Kind = eRequestedCodeElementKind Then
                        ' Found
                        objResultCodeElement = objCodeElement
                    End If
                    ' We enter in recursion, just in case there is an inner code element that also 
                    ' satisfies the conditions, for example, if we are searching a namespace or a class
                    colCodeElementMembers = GetCodeElementMembers(objCodeElement)
                    objMemberCodeElement = GetCodeElementAtTextPoint(eRequestedCodeElementKind, _
                       colCodeElementMembers, objTextPoint)
                    If Not (objMemberCodeElement Is Nothing) Then
                        ' A nested code element also satisfies the conditions
                        objResultCodeElement = objMemberCodeElement
                    End If
                    Exit For
                End If
            Next
        End If
        Return objResultCodeElement
    End Function
    Private Function GetCodeElementMembers(ByVal objCodeElement As CodeElement) As EnvDTE.CodeElements
        Dim colCodeElements As EnvDTE.CodeElements
        If TypeOf objCodeElement Is EnvDTE.CodeNamespace Then
            colCodeElements = CType(objCodeElement, EnvDTE.CodeNamespace).Members
        ElseIf TypeOf objCodeElement Is EnvDTE.CodeType Then
            colCodeElements = CType(objCodeElement, EnvDTE.CodeType).Members
        ElseIf TypeOf objCodeElement Is EnvDTE.CodeFunction Then
            colCodeElements = DirectCast(objCodeElement, EnvDTE.CodeFunction).Parameters
        End If
        Return colCodeElements
    End Function
    Sub PropertiesExample()
        ' Create and initialize a variable to represent the Documents 
        ' Options page.
        Dim envGenTab As EnvDTE.Properties = _
        DTE.Properties("Environment", "ProjectsAndSolution")
        Dim prop As EnvDTE.Property
        Dim msg As String
        ' Loop through each item in the Documents Options box.
        For Each prop In envGenTab
            msg += ("PROP NAME: " & prop.Name & "   VALUE: " & _
            prop.Value) & vbCr
        Next
        MsgBox(msg)
    End Sub
    End Module
