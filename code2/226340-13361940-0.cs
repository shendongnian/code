    using System.Windows.Forms;
    using System.Drawing;
    public class CustomPictureBox : PictureBox
    {
      protected override void OnPaint(PaintEventArgs e) 
      {
        base.OnPaint(e);
        ControlPaint.DrawBorder(e.Graphics, e.Rectangle, Color.Red, ButtonBorderStyle.Solid);
      }
    }
