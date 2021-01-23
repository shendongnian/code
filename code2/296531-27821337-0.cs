    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Threading;
    using Outlook = Microsoft.Office.Interop.Outlook;
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void ButtonSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lstAllRecipients = new List<string>();
                //Below is hardcoded - can be replaced with db data
                lstAllRecipients.Add("sanjeev.kumar@testmail.com");
                lstAllRecipients.Add("chandan.kumarpanda@testmail.com");
                Outlook.Application outlookApp = new Outlook.Application();
                Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                Outlook.Inspector oInspector = oMailItem.GetInspector;
               // Thread.Sleep(10000);
                // Recipient
                Outlook.Recipients oRecips = (Outlook.Recipients)oMailItem.Recipients;
                foreach (String recipient in lstAllRecipients)
                {
                    Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(recipient);
                    oRecip.Resolve();
                }
                //Add CC
                Outlook.Recipient oCCRecip = oRecips.Add("THIYAGARAJAN.DURAIRAJAN@testmail.com");
                oCCRecip.Type = (int)Outlook.OlMailRecipientType.olCC;
                oCCRecip.Resolve();
                //Add Subject
                oMailItem.Subject = "Test Mail";
                // body, bcc etc...
                //Display the mailbox
                oMailItem.Display(true);
            }
            catch (Exception objEx)
            {
                Response.Write(objEx.ToString());
            }
        }
    }
