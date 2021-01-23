    Module Module1
        Dim varName As New Test With {.MyBool = True, .MyString = "some string"}
        Sub Main()
            Console.WriteLine("Test Class Properties: " & varName.MyString & "-" & varName.MyBool)
            Console.WriteLine("Test Class ToString(): " & varName)
            Console.ReadKey()
        End Sub
    End Module
