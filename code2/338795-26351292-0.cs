        private void HookControl(Control controlToHook)
        {
            // Add any extra "unfocusable" control types as needed
            if (controlToHook.GetType() == typeof(Panel)
                || controlToHook.GetType() == typeof(GroupBox)
                || controlToHook.GetType() == typeof(Label)
                || controlToHook.GetType() == typeof(TableLayoutPanel)
                || controlToHook.GetType() == typeof(FlowLayoutPanel)
                || controlToHook.GetType() == typeof(TabControl)
                || controlToHook.GetType() == typeof(TabPage)
                || controlToHook.GetType() == typeof(PictureBox))
            {
                controlToHook.MouseClick += AllControlsMouseClick;
            }
            foreach (Control ctl in controlToHook.Controls)
            {
                HookControl(ctl);
            }
        }
        void AllControlsMouseClick(object sender, MouseEventArgs e)
        {
            FocusLabels(this);
        }
        private void FocusLabels(Control control)
        {
            if (control.GetType() == typeof(Label))
            {
                control.Focus();
            }
            foreach (Control ctl in control.Controls)
            {
                FocusLabels(ctl);
            }
        }
