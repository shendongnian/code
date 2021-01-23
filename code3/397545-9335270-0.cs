    public MailMessage CreateMailMessage(string to, string from, String subject, String body, string iCal)
            {
                MailMessage message = new MailMessage(from, to);
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = false;
    
                ContentType calType = new ContentType("text/calendar");
                //NOTE MUST MATCH iCal Method for RFC2445
                calType.Parameters.Add("method", "REQUEST");
    
                AlternateView calendarView = AlternateView.CreateAlternateViewFromString(iCal, calType);
                calendarView.TransferEncoding = TransferEncoding.Base64;
    
                message.AlternateViews.Add(calendarView);
    
                return message;
            }
