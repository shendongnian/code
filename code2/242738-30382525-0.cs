    public  static class ControlsExtensions
    {
        public static void ClearControls(this Control frm)
        {
            foreach (Control control in frm.Controls)
            {
                if (control is TextBox)
                {
                    control.ResetText();
                }
                if (control.Controls.Count > 0)
                {
                    control.ClearControls();
                }
            }
        }
    }
