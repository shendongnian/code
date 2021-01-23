    namespace aaaaa
    {
    public class Global : System.Web.HttpApplication
    {
        private Stopwatch sw = null;
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
                sw = Stopwatch.StartNew();
        }
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            if (sw != null)
            {
                sw.Stop();
                Response.Write("took " + sw.Elapsed.TotalSeconds.ToString("0.#######") + " seconds to generate this page");
            }
        }
    }
    }
