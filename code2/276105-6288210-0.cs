    	Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
		' Fires when an error occurs
		Dim appException As System.Exception = Server.GetLastError()
		Dim tempException As System.Exception = Nothing
		If appException Is Nothing Then
			Return
		End If
		tempException = appException.InnerException
