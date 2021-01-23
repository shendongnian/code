    public class ReadOnlyCheckBox : System.Windows.Forms.CheckBox
    {
            private bool readOnly;
    
            protected override void OnClick(EventArgs e)
            {
                    // pass the event up only if its not readlonly
                    if (!ReadOnly) base.OnClick(e);
            }
            
            public bool ReadOnly
            {
                    get { return readOnly; }
                    set { readOnly = value; }
            }
    }
