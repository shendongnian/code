    using System;
    using System.Windows.Forms;
    using SHDocVw;
    class Program
    {
        static System.Windows.Forms.WebBrowser browser;
        [STAThread]
        static void Main()
        {
            var fileName = "http://google.com";
            browser = new System.Windows.Forms.WebBrowser();
            browser.ScriptErrorsSuppressed = true;
            browser.DocumentCompleted += browser_DocumentCompleted;
            browser.Navigate(fileName);
            Application.Run();
        }
        private static void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var iwb2 = (IWebBrowser2)browser.ActiveXInstance;
            var events = (DWebBrowserEvents2_Event)browser.ActiveXInstance;
            events.PrintTemplateTeardown += browser_PrintTemplateTeardown;
            var missing = Type.Missing;
            iwb2.ExecWB(OLECMDID.OLECMDID_PRINT, OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, ref missing, ref missing);
        }
        private static void browser_PrintTemplateTeardown(object pDisp)
        {
            browser.Dispose();
            Application.Exit();
        }
    }
