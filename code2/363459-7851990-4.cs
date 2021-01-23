        public static void FormState(Form form, bool enabled)
        {
            foreach (Control c in form.Controls)
            {
                c.Enabled = enabled;
                c.Invalidate();
            }
            
            form.Refresh();
        }
