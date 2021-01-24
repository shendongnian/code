    public partial class ThisAddIn
    {
        public static Visio.Application e_application;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            e_application = this.Application;
            e_application.DocumentOpened += new Visio.EApplication_DocumentOpenedEventHandler(e_Application_DocumentOpened);
        }
       
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            e_application.DocumentOpened -= new Visio.EApplication_DocumentOpenedEventHandler(e_Application_DocumentOpened);
            e_application = null;
        }
        private void e_Application_DocumentOpened(Visio.IVDocument doc)
        {
            //whatever you need to do for this event
        }
    }
