    public class EditableComboBox : ComboBox
    {
        protected int backupIndex;
        protected string backupText;
        protected override void OnDropDown(EventArgs e)
        {
            backupIndex = this.SelectedIndex;
            if (backupIndex == -1) backupText = this.Text;
            else backupText = null;
            base.OnDropDown(e);
        }
        protected override void OnSelectionChangeCommitted(EventArgs e)
        {
            backupIndex = -2;
            base.OnSelectionChangeCommitted(e);
        }
        protected override void OnSelectionIndexChanged(EventArgs e)
        {
            backupIndex = -2;
            base.OnSelectionIndexChanged(e);
        }
        protected override void OnDropDownClosed(EventArgs e)
        {
            if (backupIndex > -2 && this.SelectedIndex != backupIndex)
            {
                if (backupIndex > -1)
                {
                    this.SelectedIndex = backupIndex;
                }
                else
                {
                    string oldText = backupText;
                    this.SelectedIndex = -1;
                    this.Text = oldText;
                    this.SelectAll();
                }
            }
            base.OnDropDownClosed(e);
        }
    }
