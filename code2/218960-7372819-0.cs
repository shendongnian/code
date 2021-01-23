    public class MyToolStripComboBox : ToolStripComboBox
    {
        private bool _isDropped;
        public MyToolStripComboBox()
        {
            this.ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
        }
        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!_isDropped)
                ((HandledMouseEventArgs)e).Handled = true;
        }
        protected override void OnDropDown(EventArgs e)
        {
            _isDropped = true;
            base.OnDropDown(e);
        }
        protected override void OnDropDownClosed(EventArgs e)
        {
            _isDropped = false;
            base.OnDropDownClosed(e);
        }
    }
