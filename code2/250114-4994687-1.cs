    Public Class Global_asax
        Inherits System.Web.HttpApplication
    
        Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
            ' Fires when an error occurs
        End Sub
    
        Private Sub Global_asax_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
            'Catches all errors
        End Sub
    End Class
