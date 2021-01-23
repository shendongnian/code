    Private Sub SomeMethod(ByVal variable As Integer)
        AddHandler Me.SomeEvent,
            Sub()
                If (variable = 1) Then
                    Me.DoSomething()
                End If
            End Sub
        Console.WriteLine("ciao")
    End Sub
