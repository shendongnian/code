        public static Control FindControlRecursive(Control control, string id)
        {
            if (control == null) return null;
            Control ctrl = control.FindControl(id);
            if (ctrl == null)
            {
                foreach (Control child in control.Controls)
                {
                    ctrl = FindControlRecursive(child, id);
                    if (ctrl != null) break;
                }
            }
            return ctrl;
        }
