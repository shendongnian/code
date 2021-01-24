    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //enable keyboard intercepts
            KeyboardHooking.SetHook();
        }
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            //disable keyboard intercepts
            KeyboardHooking.ReleaseHook();
        }
    }
