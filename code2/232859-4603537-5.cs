    public class ObservedForm : Form
    {
         public event EventHandler UserActivity;
         public ObservedForm()
         {
             KeyPreview = true;
             
             FormClosed += ObservedForm_FormClosed;
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
         private void ObservedForm_FormClosed(object sender, FormClosedEventArgs e)
         {
             FormClosed -= ObservedForm_FormClosed;
             MouseMove -= ObservedForm_MouseMove;
             KeyDown -= ObservedForm_KeyDown;
         }
    }
