     public class emailController : Controller
    
     {
        //
        // GET: /email/
        public static void CreateMessageWithAttachment(string invoiceNumber)
        {
            try
            {
                Outlook.Application oApp = new Outlook.Application();
                Outlook.MailItem email = (Outlook.MailItem)(oApp.CreateItem(Outlook.OlItemType.olMailItem));
                Models.DYNAMICS_EXTEntities _db = new Models.DYNAMICS_EXTEntities();
                string recipient = null;
                string messageBody = null;
                #region set email recipients
                {
                    ObjectParameter[] parameters = new ObjectParameter[1];
                    parameters[0] = new ObjectParameter("InvoiceNumber", invoiceNumber);
                    List<Models.EmailAddress> emailList = _db.ExecuteFunction<Models.EmailAddress>("uspGetEmailAddress", parameters).ToList<Models.EmailAddress>();
                    if(!string.IsNullOrEmpty(emailList[0].Email.ToString()))
                        recipient = emailList[0].Email.ToString().Trim();
                    else
                        recipient = " ";
                    email.Recipients.Add(recipient);
                }
                #endregion
                //email subject                 
                email.Subject = "Invoice # " + invoiceNumber;
                #region set email Text
                {
                    Models.EmailText emailText = _db.ExecuteFunction<Models.EmailText>("uspEmailText").SingleOrDefault();
                    messageBody = emailText.EmailTextLine1.ToString().Trim() + "\n\n\n\n\n\n\n\n\n";
                    messageBody += emailText.EmailTextLine2.ToString().Trim() + "\n";
                    messageBody += emailText.EmailTextLine3.ToString().Trim();
                    email.Body = messageBody;
                }
                #endregion
                #region email attachment
                {
                    string fileName = invoiceNumber.Trim();
                    string filePath = HostingEnvironment.MapPath("~/Content/reports/");
                    filePath = filePath + fileName + ".pdf";
                    fileName += ".pdf";
                    int iPosition = (int)email.Body.Length + 1;
                    int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
                    Outlook.Attachment oAttach = email.Attachments.Add(filePath, iAttachType, iPosition, fileName);
                }
                #endregion
                
                email.Display();
                //uncomment below line to SendAutomatedEmail emails atomaticallly
                //((Outlook.MailItem)email).Send(); 
            }
            catch (Exception e)
            {
            }
        }
