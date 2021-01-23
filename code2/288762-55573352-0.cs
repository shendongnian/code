    public class ReadOnlyCheckBox : System.Windows.Forms.CheckBox
    {
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.DefaultValue(false)]
        public bool ReadOnly { get; set; } = false;
        protected override void OnMouseEnter(EventArgs eventargs)
        {
            // Disable highlight when the cursor is over the CheckBox
            if (!ReadOnly) base.OnMouseEnter(eventargs);
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs mevent)
        {
            // Disable reacting (logically or visibly) to a mouse click
            if (!ReadOnly) base.OnMouseDown(mevent);
        }
    }
