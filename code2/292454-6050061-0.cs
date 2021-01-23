    public static class ControlExtension
    {
    
        public static void SetControlZIndex(this Control ctrl, int z)
        {
           ctrl.Parent.Controls.SetChildIndex(ctrl, z);
        }
    }
