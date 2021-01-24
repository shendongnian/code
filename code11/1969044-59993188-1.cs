public async void Send(List<string> toAddress, string subject, string body, bool sendAsync = true)
{
    var mimeMessage = new MimeMessage(); // MIME : Multipurpose Internet Mail Extension
    mimeMessage.From.Add(new MailboxAddress(_fromAddressTitle, _fromAddress));
    toAddress.ForEach(address => mimeMessage.To.Add(new MailboxAddress(address)));
...
if you use this method, you will need to send in the list as well.. not a single email address string.
List<string> toAddress = new List<string>() { "firstEmail", "Second" ...};
_emailSender.Send(toAddress, subject, body);
// You will not be able to do send in single string
_emailSender.Send("firstemail@only.com", subject, body); //Exception no method found.
**Send in a delimited list**
2. Always send in comma separated email addresses and translate those to multiple addresses when adding them to To field of your mimeMessage.
public async void Send(string toAddress, string subject, string body, bool sendAsync = true)
{
    var mimeMessage = new MimeMessage(); // MIME : Multipurpose Internet Mail Extension
    mimeMessage.From.Add(new MailboxAddress(_fromAddressTitle, _fromAddress));
    // HERE -> FOREACH string, not char.
    foreach (string toAddresses in toAddress.Split(',')) // Split on ,
    {
        mimeMessage.To.Add(new MailboxAddress(toAddresses)); 
    }
and you will need to use this method the following way...
List<string> toAddress = new List<string>() {"first", "..."};
_emailSender.Send(string.Join(',',toAddress), subject, body);
*Please dont forget to upvote/mark the post as answered if it resolved your question*
