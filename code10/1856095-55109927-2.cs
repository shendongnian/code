    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace DesktopApp1
    {
        public partial class MyView : System.Windows.Forms.UserControl
        {
    
            protected Color SelectedColor { get; set; } = Color.Red;
            protected Color NormalColor { get; set; } = Color.Blue;
            protected override void OnPaint(PaintEventArgs e)
            {
                using (SolidBrush blueBrush = new SolidBrush(this.Focused?SelectedColor:NormalColor))
                using (Pen blackPen = new Pen(Color.Black, 3))
                {
                    e.Graphics.FillRectangle(blueBrush, ClientRectangle);
    
                    Rectangle inset = new Rectangle(this.ClientRectangle.X + 1, this.ClientRectangle.Y + 1, this.ClientRectangle.Width -3 , this.ClientRectangle.Height - 3);
                    e.Graphics.DrawRectangle(blackPen, inset);
                }
                base.OnPaint(e);
            }
    
            private void OnButton1Clicked(object sender, EventArgs e)
            {
                this.Select();
            }
    
            protected override void OnGotFocus(EventArgs e)
            {
                Invalidate();
                base.OnGotFocus(e);
            }
    
            protected override void OnLostFocus(EventArgs e)
            {
                base.OnLostFocus(e);
                Invalidate();
            }
        }
    }
