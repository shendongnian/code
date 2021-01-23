    Class Example
        Public Property Prop As Integer
        Public Sub Test(ByRef arg As Integer)
            arg = 42
        End Sub
        Public Sub Run()
            Test(Prop)   '' No problem
        End Sub
    End Class
