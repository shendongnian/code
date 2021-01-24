C#
var sb = new StringBuilder();
using (var mc = new SmtpClient() {
    Host = "127.0.0.1", // Current HMailServer installation - will be changed to external API
    DeliveryMethod = SmtpDeliveryMethod.Network,
    Port = 25,
    UseDefaultCredentials = false,
    Credentials = new NetworkCredential("Username", "Password")
})
{
    foreach(var result in GetData())
    {
        using(var mm = new MailMessage())
        {
            mm.To.Add(new MailAddress(result.Email, result.FirstName + " " + result.Surname));
            mm.Subject = "Your monthly report";
            mm.From = new MailAddress("noreply@example.com");
            mm.ReplyToList.Add(new MailAddress("admin@example.com"));
            // Email body constructed here for each individual recipient
            mm.Body = sb.ToString();
            sb.Clear();
            await mc.SendAsync(mm);
        }
    }
}
Now, if you want to do it *concurrently*, then you'll want to use `Task.WhenAll`:
C#
using (var mc = new SmtpClient() {
    Host = "127.0.0.1", // Current HMailServer installation - will be changed to external API
    DeliveryMethod = SmtpDeliveryMethod.Network,
    Port = 25,
    UseDefaultCredentials = false,
    Credentials = new NetworkCredential("Username", "Password")
})
{
    var tasks = GetData().Select(result =>
    {
        using(var mm = new MailMessage())
        {
            mm.To.Add(new MailAddress(result.Email, result.FirstName + " " + result.Surname));
            mm.Subject = "Your monthly report";
            mm.From = new MailAddress("noreply@example.com");
            mm.ReplyToList.Add(new MailAddress("admin@example.com"));
            var sb = new StringBuilder();
            // Email body constructed here for each individual recipient
            mm.Body = sb.ToString();
            await mc.SendAsync(mm);
        }
    });
    await Task.WhenAll(tasks);
}
(note that the `StringBuilder` is no longer shared)
I haven't used the SendGrid SMTP API at scale, but I have hit their REST API with a considerable number of requests.
