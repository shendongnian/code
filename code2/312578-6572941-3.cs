    Private Function IsClassType(ByVal elem As CodeElement) As Boolean
        Return TypeOf elem Is CodeClass OrElse TypeOf elem Is CodeStruct OrElse TypeOf elem Is CodeInterface
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
