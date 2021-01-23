    class MainForm : Form
    {
        // stuff
    }
    
    class ChildForm : Form
    {
        private MainForm _mainFrm;
        public ChildForm( MainForm frm )
        {
            _mainFrm = frm;
        }
    
        private void someButton_Click( ... )
        {
            _mainFrm.UpdateSomeText();
        }
    }
