    Partial Class UserControls_UC_Menu
        Inherits System.Web.UI.UserControl
    
        Public Event SomethingChanged As EventHandler
    
        Public Sub SomethingHappend()
            RaiseEvent SomethingChanged(Me, EventArgs.Empty)
        End Sub
    
    End Class
