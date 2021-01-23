    Public Class Email    
    Sub NewHeadlessEmail(fromEmail As String, password As String, toAddress As String, subject As String, body As String)
            Using myMail As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
                myMail.From = New MailAddress(fromEmail)
                myMail.To.Add(toAddress)
                myMail.Subject = subject
                myMail.IsBodyHtml = True
                myMail.Body = body
                Using s As New Net.Mail.SmtpClient("smtp.gmail.com", 587)
                    s.DeliveryMethod = SmtpDeliveryMethod.Network
                    s.UseDefaultCredentials = False
                    s.Credentials = New Net.NetworkCredential(myMail.From.ToString(), password)
                    s.EnableSsl = True
                    s.Send(myMail)
                End Using
            End Using
        End Sub
    End Class
