	<WebMethod()> _
	 Public Function SendEmailViaPickupDir(ByVal FromAddress As String, ByVal ToList As String, ByVal CcList As String, ByVal BccList As String, _
						ByVal Subject As String, ByVal MessageBody As String, ByVal IsBodyHtml As Boolean) As Boolean
		Dim msg As System.Net.Mail.MailMessage = BuildMessage(FromAddress, ToList, CcList, BccList, Subject, MessageBody, IsBodyHtml)
		If Not msg Is Nothing Then
			Return SendMessageViaPickupDir(msg)
		Else
			Return False
		End If
	End Function
	Private Function BuildMessage(ByVal FromAddress As String, ByVal ToList As String, ByVal CcList As String, ByVal BccList As String, _
		 ByVal Subject As String, ByVal MessageBody As String, ByVal IsBodyHtml As Boolean) As System.Net.Mail.MailMessage
		Dim msg As New System.Net.Mail.MailMessage
		Try
			msg.From = New System.Net.Mail.MailAddress(FromAddress)
			If Not ToList Is Nothing Then
				For Each Address As String In ToList.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
					msg.To.Add(New System.Net.Mail.MailAddress(Address.Trim()))
				Next
			End If
			If Not CcList Is Nothing Then
				For Each Address As String In CcList.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
					msg.CC.Add(New System.Net.Mail.MailAddress(Address.Trim()))
				Next
			End If
			If Not BccList Is Nothing Then
				For Each Address As String In BccList.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
					msg.Bcc.Add(New System.Net.Mail.MailAddress(Address.Trim()))
				Next
			End If
			msg.Subject = Microsoft.Security.Application.AntiXss.HtmlEncode(Subject)
			If (IsBodyHtml) Then
				msg.Body = Microsoft.Security.Application.AntiXss.GetSafeHtmlFragment(MessageBody)
			Else
				' This was causing formatting issues...
				msg.Body = MessageBody
			End If
			msg.IsBodyHtml = IsBodyHtml
		Catch ex As Exception
			Dim s As New OverseerService
        s.WriteToSql(Convert.ToInt64(ConfigurationManager.AppSettings("OverseerWebSiteResourceid")), User.Identity.Name, _
         My.Computer.Name, ex.ToString(), MyCompany.Overseer.EventLogger.SeverityLevel.Critical)
			Return Nothing
		End Try
		Return msg
	End Function
	Private Function SendMessageViaPickupDir(ByVal msg As System.Net.Mail.MailMessage) As Boolean
		Dim ret As Boolean = False
		Try
			' try to send through pickup dir
			Dim c1 As New System.Net.Mail.SmtpClient("localhost")
			c1.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.PickupDirectoryFromIis
			c1.Send(msg)
			ret = True
		Catch ex As Exception
			Try
				' log as a known error
				Dim s As New OverseerService
				s.WriteToSql(Convert.ToInt64(ConfigurationManager.AppSettings("OverseerWebSiteResourceid")), User.Identity.Name, _
				 My.Computer.Name, "failed to write email to pickup dir " + ex.ToString(), MyCompany.Overseer.EventLogger.SeverityLevel.KnownError)
			Catch
				' ignore error from writing the error
			End Try
		End Try
		Return ret
	End Function
