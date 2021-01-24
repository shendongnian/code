    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace ConsoleBrowsers
    {
        class Program
        {
            static void Main(string[] args)
            {
                string url = "https://your.url.com";
                string[] years = { "2001", "2002", "2003"};
                string[] davas = { "1", "2", "3" };
                string taraf = "1";
    
                int completed = 0, succeeded = 0;
                var bots = new List<Bot>();
                var started = false;
    
                var idle = (EventHandler)delegate (object sender, EventArgs b)
                {
                    if (started)
                        return;
    
                    started = true;
                    foreach (var dava in davas)
                        foreach (var year in years)
                            bots.Add(new Bot { Year = year, Dava = dava, Taraf = taraf, Url = url }.Run((bot, result) =>
                            {
                                Console.WriteLine($"{result}: {bot.Year}, {bot.Dava}");
                                succeeded += result ? 1 : 0;
                                if (++completed == years.Length * davas.Length)
                                    Application.ExitThread();
                            }));
                };
    
                var forms = new Thread((ThreadStart) delegate {
                    Application.EnableVisualStyles();
                    Application.Idle += idle;
                    Application.Run();
                });
    
                forms.SetApartmentState(ApartmentState.STA);
                forms.Start();
                forms.Join();
    
                Console.WriteLine($"All bots finished, succeeded: {succeeded}, failed:{bots.Count - succeeded}.");
            }
        }
    
        class Bot
        {
            public string Url, Dava, Taraf, Year;
            public delegate void CompletionCallback(Bot sender, bool result);
    
            WebBrowser browser;
            CompletionCallback callback;
            bool submitted;
    
            public Bot Run(CompletionCallback callback)
            {
                this.callback = callback;
    
                browser = new WebBrowser();
                browser.ScriptErrorsSuppressed = true;
                browser.DocumentCompleted += Browser_DocumentCompleted;
                browser.Navigate(Url);
                return this;
            }
    
            void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                if (browser.ReadyState == WebBrowserReadyState.Complete)
                {
                    if (submitted)
                    {
                        callback(this, true);
                        return;
                    }
    
                    var ok = SetValue("DropDownList1", Dava);
                    ok &= SetValue("DropDownList3", Taraf);
                    ok &= SetValue("DropDownList4", Year);
                    if (ok)
                        ok &= Click("Button1");
    
                    if (!(submitted = ok))
                        callback(this, false);
                }
            }
    
            bool SetValue(string id, string value, string name = "value")
            {
                var e = browser?.Document?.GetElementById(id);
                e?.SetAttribute(name, value);
                return e != null;
            }
    
            bool Click(string id)
            {
                var element = browser?.Document?.GetElementById(id);
                element?.InvokeMember("click");
                return element != null;
            }
        }
    }
