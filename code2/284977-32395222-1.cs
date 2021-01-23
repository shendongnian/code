    protected void SendEmail(object sender, EventArgs e)
       {
           try
           {
               using (StringWriter sw = new StringWriter())
               {
                   using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                   {
                      // GridView5.DataBind();
                       GridView5.RenderControl(hw);//this is my gridview name
                       StringReader sr = new StringReader(sw.ToString());
                       MailMessage mm = new MailMessage("gowdhaman92@gmail.com",                    "gowdhaman92@gmail.com");//From and To Mail id's
                       mm.Subject = "Quotation from INDIAN Departmental store,Udumalpet";
                       mm.Body = "INDIAN Departmental store,Udumalpet:<hr />" + sw.ToString();
                       mm.IsBodyHtml = true;
                       SmtpClient smtp = new SmtpClient();
                       smtp.Host = "smtp.gmail.com";
                       smtp.EnableSsl = true;
                       System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                       NetworkCred.UserName = "gowdhaman92@gmail.com";
                       NetworkCred.Password = "perumalpudur";
                       smtp.UseDefaultCredentials = true;
                       smtp.Credentials = NetworkCred;
                       smtp.Port = 587;
                       smtp.Send(mm);
                       ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert message", "alert('mail sent');", true);
                   }
               }
           }
           catch (Exception)
           {
               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Mail not sent!!!');", true);
           }
       }
      
           public override void VerifyRenderingInServerForm(Control control)
       {
           /* Verifies that the control is rendered */
       }
      
