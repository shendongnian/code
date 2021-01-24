smtp.AuthenticationMechanisms.Remove("XOAUTH2");
That will do what you need.
Here's an example of what the whole thing should look like:
string FromPseudonym = "MySite Support";
string FromAddress = "admin@MySite.com";
var message = new MimeMessage();
message.From.Add(new MailboxAddress(FromPseudonym, FromAddress));
message.To.Add(new MailboxAddress("Recipient Pseudonym", "RecipientAddress@somewhere.com"));
message.Subject = "Testing Email";
var bodyBuilder = new BodyBuilder();
                
string MsgBody = "Message Body stuff goes here";
bodyBuilder.HtmlBody = MsgBody;
message.Body = bodyBuilder.ToMessageBody();
using (var client = new SmtpClient())
{
    client.Connect("smtp.office365.com", 587);
    client.AuthenticationMechanisms.Remove("XOAUTH2");
    client.Authenticate(FromAddress, "Your super secret password goes here");
    client.Send(message);
    client.Disconnect(true);
}
You'll need the following namespaces to be included:
using MimeKit;
using MimeKit.Utils;
using MailKit.Net.Smtp;
