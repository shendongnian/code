        Protected Sub gvAddresses_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvAddresses.RowDeleting
    
            Dim selectedAddessId As Label = gvAddresses.Rows(e.RowIndex).FindControl("Label13")
            SqlDataSource.DeleteParameters("add_id").DefaultValue = selectedAddessId.Text
            SqlDataSource.Delete()
    End Sub
