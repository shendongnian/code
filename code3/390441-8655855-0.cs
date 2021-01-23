    public class EscapingToolStripCheckBox : CustomControls.ToolStripCheckBox
    {
        private EscapingToolStripDropDownButton _parent;
        public EscapingToolStripCheckBox(EscapingToolStripDropDownButton parent)
            : base()
        {
            _parent = parent;
        }
        protected override bool ProcessCmdKey(ref Message m, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                _parent.HandleSelection(false);
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                _parent.HandleSelection(true);
                return true;
            }
            // Dont need to execute HandleSelection under any other condition. 
            return base.ProcessCmdKey(ref m, keyData);
        }
    }
