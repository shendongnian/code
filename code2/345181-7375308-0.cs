    public class SplashScreen : Form
    {
        // add a timer to your form with desired interval to show
        protected override void OnShown(EventArgs e)
        {
            displayTimer.Start();
            base.OnShown(e);
        }
        private void displayTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public class MainForm : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            // splash screen will be shown before your main form tries to show itself
            using (var splash = new SplashScreen())
                splash.ShowDialog();
            base.OnLoad(e);
        }
    }
