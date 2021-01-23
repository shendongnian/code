    <System.Runtime.CompilerServices.Extension()> _
    Public Sub EnableChildViewState(ByVal parentControl As System.Web.UI.Control, enable as Boolean) 
        If parentControl.HasControls Then
            For Each c As System.Web.UI.Control In parentControl.Controls
                c.EnableViewState = enable 
                EnableChildViewState(c, enable)
            Next
        End If
    End Sub
