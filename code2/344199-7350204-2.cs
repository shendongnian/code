    Public Class MainViewModel
        Inherits ViewModelBase
    
        Public Property MyClassCollection as New ObservableCollection(Of MyClassViewModel)
    
    End Class
	Public Class MyClassViewModel
		Inherits ViewModelBase
		Public Property ModelClass as MyClass
		Public Sub New()
		End Sub
		Public Sub New(ByRef CustClass as MyClass)
			ModelClass = CustClass
		End Sub
	End Class
