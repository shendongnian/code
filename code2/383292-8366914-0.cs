    public class Global : System.Web.HttpApplication
    {
        private static Timer timer;
        protected void Application_Start(object sender, EventArgs e)
        {
            timer = new Timer(5 * 60 * 1000);
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //Get our emails here
        }
    }
