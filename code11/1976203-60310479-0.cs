 c#
class Program
{
    static void Main(string[] args)
    {
        string command = string.Empty;
        while (command != "exit")
        {
            Console.Write("# ");
            command = Console.ReadLine();
            switch (command)
            {
                case "go":
                    Thread t = new Thread(() =>
                    {
                        WebBrowser browser = new WebBrowser();
                        browser.DocumentCompleted += Browser_DocumentCompleted;
                        browser.Navigating += Browser_Navigating;
                        browser.Navigate("http://localhost"); // set url here
                        Application.Run();
                    });
                    t.SetApartmentState(ApartmentState.STA);
                    t.Start();
                    t.Join();
                    break;
            }
        }
        Console.WriteLine("Bye! Press any key...");
        Console.ReadKey();
    }
    private static void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
    {
        Console.WriteLine("Navigating: {0}", e.Url);
    }
    private static void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        if (sender is WebBrowser browser)
        {
            Console.WriteLine("Loaded: {0}", e.Url);
            HtmlDocument doc = browser.Document;
            // do your job here with DOM of the HtmlDocument
            Console.WriteLine(doc.Body.InnerHtml);
            // additionally you may call browser.navigate here again and return; avoiding ExitThread
        }
        Application.ExitThread();
    }
}
This program load and show you HTML of web page using WinForms `WebBrowser` Control (Internet Explorer). I signed with comment where suggested to add processing of [`HtmlDocument`][1] received from web.
Making it clearer, there's way to submit the form calling `Click()` of the Submit button. It's something like you can do almost the same programmatically as user can do manually in a regular browser.
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.htmldocument?view=netframework-4.0
