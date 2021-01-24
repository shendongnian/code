csharp
public class CustomSmtpMailer : SmtpClient {
    internal delegate void SendInternal(MailMessage message);
    private SendInternal _sendAction;
    // make sure all your constructors call this one.
    // this will make the call to base.Send(MailMessage) the default behaviour.
    public CustomSmtpMailer() {
        _sendAction = delegate (MailMessage message) { Send(message); };
    }
    // customizes the SendMail(MailMessage) behaviour for testing purposes.
    internal CustomSmtpMailer(SendInternal sendAction) {
        _sendAction = sendAction;
    }
    private void SendMail(MailMessage mailMessage) {
        //DoSomeStuff
        _sendAction(mailMessage);
    }
}
Make the internal members visible to your test project by adding this to your `AssemblyInfo.cs` in your project.
csharp
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("My.Test.Assembly.Name")]
In your unit test you can use the internal constructor to configure the base call.
csharp
[Fact]
public void SendMail() {
    CustomSmtpMailer service = new CustomSmtpMailer(delegate (MailMessage message) {
        Console.WriteLine("I'm a custom Action that can be used for testing");
    });
    MailMessage mailMessage = new MailMessage();
    // Find on web but not available :(
    Mock.Arrange(() => new SmtpClient().Send()).Returns(null).IgnoreInstance();
    service.SendMail(mailMessage);
}
