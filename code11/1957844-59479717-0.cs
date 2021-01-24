csharp
var emailHtml = EmailTemplate.EmailHtml();
var smsHtml = SmsTemplate.SmsHtml();
run the loop _synchronously_ and return a completed task. Then the `Task.WhenAll` also returns a completed task. There is never any asynchrony, no continuations, only plain old sequential execution.
Making your method `async` doesn't magically cause it to be ran on a separate thread, actually, [There Is No Thread](https://blog.stephencleary.com/2013/11/there-is-no-thread.html). Your task has nothing to do with asynchronous operations. If you want to run CPU-bound tasks on the thread pool, use `Task.Run`
csharp
public class EmailTemplate
{
    public static string EmailHtml()
    {
        string str = string.Empty;
        for (int i = 0; i < 25000; i++)
        {
            str += "html1" + i + " ";
            str += "html1" + i + " ";
        }
        return str;
    }
}
public class SmsTemplate
{
    public static string SmsHtml()
    {
        string str = string.Empty;
        for (int i = 0; i < 25000; i++)
        {
            str += "html2" + i + " ";
            str += "html2" + i + " ";
        }
        return str;
    }
}
class Program
{
    static async Task Main(string[] args)
    {
        var startTime = DateTime.Now;
        Console.WriteLine($"Start time: {startTime}");
        var emailHtml = Task.Run(() => EmailTemplate.EmailHtml());
        var smsHtml = Task.Run(() => SmsTemplate.SmsHtml());
        var f = await Task.WhenAll(emailHtml, smsHtml);
        var endTime = DateTime.Now;
        Console.WriteLine($"End time: {endTime}");
        Console.ReadLine();
    }
}
As an aside, don't you think that concatenating a string 25000 times taking _9 seconds_ is a bit pathological? I do, that's why [I'd use a `StringBuilder`](https://docs.microsoft.com/en-us/dotnet/standard/base-types/stringbuilder).
csharp
public static string EmailHtml()
{
    var stringBuilder = new StringBuilder();
    for (int i = 0; i < 25000; i++)
    {
        stringBuilder.Append("html1").Append(i).Append(" ");
        // I don't know if this duplication is intentional, but I left it in case it was.
        stringBuilder.Append("html1").Append(i).Append(" ");
    }
    return stringBuilder.ToString();
}
