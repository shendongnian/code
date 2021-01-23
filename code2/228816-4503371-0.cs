    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    static class Utils {
        public static Form Plexiglass(Form tocover) {
            var frm = new Form();
            frm.BackColor = Color.DarkGray;
            frm.Opacity = 0.30;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.ControlBox = false;
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.Manual;
            frm.AutoScaleMode = AutoScaleMode.None;
            frm.Location = tocover.Location;
            frm.Size = tocover.Size;
            frm.Show(tocover);
            return frm;
        }
    }
