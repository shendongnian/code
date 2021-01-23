    public class ObservedForm : Form
    {
         public event EventHandler UserActivity;
         public ObservedForm()
         {
             KeyPreview = true;
             
             FormClosing += ObservedForm_FormClosing;
             MouseMove += ObservedForm_MouseMove;
             KeyDown += ObservedForm_KeyDown;
         }
         protected virtual void OnUserActivity(EventArgs e)
         {
             var ua = UserActivity;
             if(ua != null)
             {
                  ua(this, e);
             }
         }
         private void ObservedForm_MouseMove(object sender, MouseEventArgs e)
         {
              OnUserActivity();
         }
         private void ObservedForm_KeyDown(object sender, KeyEventArgs e)
         {
              OnUserActivity();
         }
         private void ObservedForm_FormClosing(object sender, FormClosingEventArgs e)
         {
             FormClosing -= ObservedForm_FormClosing;
             MouseMove -= ObservedForm_MouseMove;
             KeyDown -= ObservedForm_KeyDown;
         }
    }
