    public class SingleInstanceController : WindowsFormsApplicationBase
    {
        public SingleInstanceController()
        {
            this.IsSingleInstance = true;
        }
        /// <summary>
        /// When overridden in a derived class, allows a designer to emit code that 
        /// initializes the splash screen.
        /// </summary>
        protected override void OnCreateSplashScreen()
        {
            this.SplashScreen = new SplashScreen();
        }
        /// <summary>
        /// When overridden in a derived class, allows a designer to emit code that configures 
        /// the splash screen and main form.
        /// </summary>
        protected override void OnCreateMainForm()
        {
            // SplashScreen will close after MainForm_Load completed
            this.MainForm = new OfeMainForm();
            // HACK - gets around problem with logon form not having focus on startup
            // See also OfeMainForm_Shown in OfeMainForm.cs
            this.MainForm.WindowState = FormWindowState.Minimized;
        }
    }
    public partial class OfeMainForm : Form
    {
        // ...
        private void OfeMainForm_Shown(object sender, EventArgs e)
        {
            // HACK - gets around problem with logon form not having focus on startup
            // See also OnCreateMainForm in Program.cs
            this.WindowState = FormWindowState.Normal;
            OperatorLogon();
        }
        // ...
    
    }
