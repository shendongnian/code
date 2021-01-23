    Protected Sub gvVehicles_RowDataBound(sender As Object, e As GridViewRowEventArgs)
           
        If e.Row.RowType = DataControlRowType.DataRow Then
           Dim veh As Vehicle = TryCast(e.Row.DataItem, Vehicle)
           If Not veh Is Nothing Then
                Dim chkBox As CheckBox = CType(e.Row.FindControl("chkSelect"), CheckBox)
                    chkBox.Checked = True
           End If
        End If
    End Sub
