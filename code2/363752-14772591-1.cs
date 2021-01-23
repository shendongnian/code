    using System;
    using System.Drawing;
    using System.Windows.Forms;
    static class Utils
    {
        static Form ChildForm;
        public static Form OpenMask(Form tocover)
        {
            Form frm = new Form();
            ChildForm = frm;
            tocover.SizeChanged += AdjustPosition;
            tocover.Move += AdjustPosition;
    
            //frm.Move += AdjustPosition;
            //frm.SizeChanged += AdjustPosition;
            frm.BackColor = Color.Black;
            frm.Opacity = 0.50;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.ControlBox = false;
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.Manual;
            frm.AutoScaleMode = AutoScaleMode.None;
            //frm.Location = tocover.Location;
            frm.Location = tocover.PointToScreen(System.Drawing.Point.Empty);
            frm.Size = tocover.ClientSize;
            frm.Show(tocover);
            return frm;
        }
    
        public static void CloseMask()
        {
            if (ChildForm != null)
            {
                ChildForm.Close();
                ChildForm.Dispose();
            }
        }
    
        private static void AdjustPosition(object sender, EventArgs e)
        {
            Form parent = sender as Form;
            if (ChildForm != null)
            {
                ChildForm.Location = parent.PointToScreen(System.Drawing.Point.Empty);
                ChildForm.ClientSize = parent.ClientSize;
            }
        }
    }
