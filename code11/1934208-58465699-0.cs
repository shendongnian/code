    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public class BaseUserControl : UserControl
    {
        void WireMouseEvents(Control container)
        {
            foreach (Control c in container.Controls)
            {
                c.MouseDown += (s, e) =>
                {
                    var p = PointToThis((Control)s, e.Location);
                    OnMouseDown(new MouseEventArgs(e.Button, e.Clicks, p.X, p.Y, e.Delta));
                };
                WireMouseEvents(c);
            };
        }
        Point PointToThis(Control c, Point p)
        {
            return PointToClient(c.PointToScreen(p));
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (Control.ModifierKeys == (Keys.Control | Keys.Alt | Keys.Shift))
                MessageBox.Show("Handled!");
            // Your custom logic
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            WireMouseEvents(this);
        }
    }
