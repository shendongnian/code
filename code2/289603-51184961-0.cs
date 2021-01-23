    public static class StratoControlExtension
    {
        public static bool TruelyVisible(this Control control, Control expected_root)
        {
            if (control.Parent == null) { return control == expected_root && control.Visible; }
            return control.Parent.TruelyVisible(expected_root) && control.Visible;
        }
    }
