    public class Class1
    {
        public void SendMail(string args)
        {
            try
            {
                var oApp = new Outlook.Application();
                var oMsg = (Outlook.MailItem) oApp.CreateItem(Outlook.OlItemType.olMailItem);
                var oRecip = (Outlook.Recipient) oMsg.Recipients.Add("email@gmail.com");
                oRecip.Resolve();
                oMsg.Subject = "Deskstop Standards: Required Items";
                oMsg.Body = body
                oMsg.Display(true);
                oMsg.Save();
                oMsg.Send();
                oRecip = null;
                oMsg = null;
                oApp = null;
            }
            catch (Exception e)
            {
                Console.WriteLine("{problem with email execution} Exception caught: ", e);
            }
            return;
        }
    }
