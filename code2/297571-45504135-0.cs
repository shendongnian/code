    public class RichTextBoxZoomControl : RichTextBox
    {
        private Boolean m_AllowScrollWheelZoom = true;
        private Boolean m_AllowKeyZoom = true;
        [Description("Allow adjusting zoom with [Ctrl]+[Scrollwheel]"), Category("Behavior")]
        [DefaultValue(true)]
        public Boolean AllowScrollWheelZoom
        {
            get { return m_AllowScrollWheelZoom; }
            set { m_AllowScrollWheelZoom = value; }
        }
        [Description("Allow adjusting zoom with [Ctrl]+[Shift]+[,] and [Ctrl]+[Shift]+[.]"), Category("Behavior")]
        [DefaultValue(true)]
        public Boolean AllowKeyZoom
        {
            get { return m_AllowKeyZoom; }
            set { m_AllowKeyZoom = value; }
        }
        protected override void WndProc(ref Message m)
        {
            if (!m_AllowScrollWheelZoom && (m.Msg == 0x115 || m.Msg == 0x20a) && (Control.ModifierKeys & Keys.Control) != 0)
                return;
            base.WndProc(ref m);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (!this.m_AllowKeyZoom && e.Control && e.Shift && (e.KeyValue == (Int32)Keys.Oemcomma || e.KeyValue == (Int32)Keys.OemPeriod))
                return;
            base.OnKeyDown(e);
        }
    }
