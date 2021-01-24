               using System;
               using Outlook = Microsoft.Office.Interop.Outlook;
               using System.Runtime.InteropServices;
               
               public Class Outlook
               {
                   public void SendMail()
                   {
                        Outlook.Application outlookObj = null;
                        Outlook.Application oApp = new Outlook.Application();
                        Outlook._MailItem oMailItem = (Outlook._MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                        oMailItem.To = "xyz@gmail.com";
                        oMailItem.Subject = $"Primary user confirmed, survey sent";
                        oMailItem.Body = $"Please find below {userEmail.Text}";
                        oMailItem.Display(true);
                
                        oMailItem.Send();
                        Marshal.ReleaseComObject(oApp);
                        Marshal.ReleaseComObject(oMailItem);
                    }
               }
              
