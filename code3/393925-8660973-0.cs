    <DirectMethodProxyID(IDMode := DirectMethodProxyIDMode.[Alias], [Alias] := "UC")> _
    Public Partial Class AliasID
    	Inherits System.Web.UI.UserControl
    	<DirectMethod> _
    	Public Sub HelloUserControl()
    		X.Msg.Alert("Message", "Hello from UserControl").Show()
    	End Sub
    End Class
