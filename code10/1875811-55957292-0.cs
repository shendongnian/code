`
  public delegate void NavigateDoneEvent();
        public static event NavigateDoneEvent Done;
        private static System.Windows.Forms.Timer wait;
`
You don't need to use this as static.
After that you need to create this function
`
 public static void Wait(WebBrowser Browser, string Url, double Seconds)
        {
            Browser.Navigate(Url);
            wait = new System.Windows.Forms.Timer();
            wait.Interval = Convert.ToInt32(Seconds * 1000);
            wait.Tick += (s, args) =>
            {
                if (Done != null) Done();
                wait.Enabled = false;
            };
            wait.Enabled = true;
        }
`
And you can call this function like:
`
Wait(webBrowser1, "somesite.com", 20);
            Done += afterWaitDoSomething;
`
