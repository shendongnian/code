    <Extension()> _
    Public Function DisableChildViewState(ByVal parentControl As System.Web.UI.Control) As System.Web.UI.Control
        If parentControl.HasControls Then
            For Each c As System.Web.UI.Control In parentControl.Controls
                c.EnableViewState = False
                DisableChildViewState(c)
            Next
        End If
    End Function
