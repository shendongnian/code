    using System;
    using System.Data;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Net.Mail;
    
    public partial class _Default : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
    try
    {
    MailAddress SendFrom = new MailAddress(txtFrom.Text);
    MailAddress SendTo = new MailAddress(txtTo.Text);
    
    MailMessage MyMessage = new MailMessage(SendFrom, SendTo);
    
    MyMessage.Subject = txtSubject.Text;
    MyMessage.Body = txtBody.Text;
    
    Attachment attachFile = new Attachment(txtAttachmentPath.Text);
    MyMessage.Attachments.Add(attachFile);
    
    SmtpClient emailClient = new SmtpClient(txtSMTPServer.Text);
    emailClient.Send(MyMessage);
    
    litStatus.Text = "Message Sent";
    }
    catch (Exception ex)
    {
    litStatus.Text=ex.ToString();
    }
    }
    }
