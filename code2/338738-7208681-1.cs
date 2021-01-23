    public class YourForm : Form
    {
      private async void UpPictureBox_Click(object sender, EventArgs args)
      {
        await TaskEx.Delay(500);
        timer1.Enabled = is_mouse_down;
      }
      private async void DownPictureBox_Click(object sender, EventArgs args)
      {
        await TaskEx.Delay(500);
        timer1.Enabled = is_mouse_down;
      }
    }
