            //Table to store our GridView Data
            Table table = new Table();
            //Parse our GridView into Table, stored in a StringBuilder
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    //  header
                    if (GridView1.HeaderRow != null)
                    {
                        table.Rows.Add(GridView1.HeaderRow);
                    }
                    //  details
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        table.Rows.Add(row);
                    }
                    //  footer
                    if (GridView1.FooterRow != null)
                    {
                        table.Rows.Add(GridView1.FooterRow);
                    }
                    //  render table
                    table.RenderControl(htw);
                }
            }
            
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(memoryStream))
                {
                    //Convert StringBuilder to MemoryStream
                    writer.Write(sb.ToString());
                    writer.Flush();
                    //Create Message
                    MailMessage message = new MailMessage();
                    message.To.Add(new MailAddress("you@address.com", "You"));
                    message.From = new MailAddress("me@address.com", "Me");
                    message.Subject = "The Subject";
                    //Create Attachment
                    Attachment attachment = new Attachment(memoryStream, "InvoiceSummary.xls", "application/vnd.xls");
                    //Attach Attachment to Email
                    message.Attachments.Add(attachment);
                    //Open SMTP connection to server and send
                    SmtpClient smtp = new SmtpClient();
                    smtp.Port = 25;
                    smtp.Send(message);
                }
            }
