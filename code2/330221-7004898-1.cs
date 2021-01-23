    public partial class ParentForm : Form
    {
        private void ParentForm_Load(object sender, EventArgs e)
        {
             var timer = new TimerUserControl();
             //Subscribe to the expired event that we defined above.
             timer.Expired += new EventArgs(Timer_Expired);
        }
        public void Timer_Expired(object sender, EventArgs e)
        {
            //Handle the timer expiring here. Sounds like you are calling another function, so do that here.
        }
    }
