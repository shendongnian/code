    Public Event SomethingChanged As EventHandler
    
    Private Sub UC_MenuInstance_SomethingChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UC_Menu.SomethingChanged
         RaiseEvent Me.SomethingChanged(Me, EventArgs.Empty)
    End Sub
