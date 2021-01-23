	Public Delegate Sub MyDelegate()
	Public Class Class1
		Public Event SomeEvent As MyDelegate
		Private Class MyDelegateClass
			Public Owner As Class1
			Public Variable As Integer
			Public Sub Method()
				If (Variable = 1) Then
					Owner.DoSomething()
				End If
			End Sub
		End Class
		Private Sub SomeMethod(ByVal variable As Integer)
			Dim dc As New MyDelegateClass
			dc.Owner = Me
			dc.Variable = variable
			AddHandler Me.SomeEvent, AddressOf dc.Method
			Console.WriteLine("ciao")
		End Sub
		Public Sub DoSomething()
			Console.WriteLine("hello")
		End Sub
	End Class
