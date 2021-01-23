    Public Interface IRequestCloseViewModel
    
        //Event RequestClose As EventHandler
        Event RequestClose(ByVal sender As Object, ByVal e As EventArgs)
    
    End Interface
    
    Public Class ApplicationWindowBase
        Inherits Window
    
        Public Sub New()
            AddHandler Me.DataContextChanged, AddressOf OnDataContextChanged
        End Sub
    
        Private Sub OnDataContextChanged(ByVal sender As Object, ByVal e As DependencyPropertyChangedEventArgs)
    
            Dim request = TryCast(e.NewValue, IRequestCloseViewModel)
    
            If request IsNot Nothing Then
                AddHandler request.RequestClose, Sub(sender, event) Me.Close
                //Bear in mind you cannot do Sub(x,y) in VS pre 2010    
            End If
    
        End Sub
    
    End Class
