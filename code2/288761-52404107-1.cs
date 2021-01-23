    public class CtrlCheckBoxReadOnly : System.Windows.Forms.CheckBox
    {
        [Category("Appearance")]
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public bool ReadOnly { get; set; }
        protected override void OnClick(EventArgs e)
        {
            if (!ReadOnly) base.OnClick(e);
        }
    }
