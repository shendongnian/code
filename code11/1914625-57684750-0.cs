  private void button1_Click(object sender, EventArgs e)
        {
            Navigate n = new Navigate();
            n.Done += delegate
            {
                MessageBox.Show("");
            };
    //wb is the webbrowser, nav is the url
            n.Wait(wb, nav, 1);
        }
        public class Navigate
        {
            public delegate void NavigateDoneEvent();
            public event NavigateDoneEvent Done;
            private Timer wait;
            HtmlElement e2 = null;
            public void Wait(WebBrowser Browser, string Url, double Seconds)
            {
                Browser.Navigate(Url);
                wait = new Timer();
                wait.Interval = Convert.ToInt32(Seconds * 1000);
                wait.Tick += (s, args) =>
                {
                    if (Form1.wb.Document != null)
                    {
                        HtmlElementCollection c1 = Form1.wb.Document.GetElementsByTagName("element tag type");
                        foreach (HtmlElement e3 in c1)
                        {
                            if (e3.GetAttribute("className") == "class name")
                            {
                                if (e3.InnerText.Contains("something"))
                                {
                                    e2 = e3;
                                    wait.Enabled = false;
                                    MessageBox.Show(e2.InnerText);
                                    Done();
                                }
                            }
                        }
                    }
                };
                wait.Enabled = true;
            }
        }
