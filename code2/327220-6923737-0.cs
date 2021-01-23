    using System.Windows.Forms;
    public class B
    {
        public B()
        {
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        }
        void Application_ApplicationExit(object sender, EventArgs e)
        {
            //do cleanup of your class
        }
    }
