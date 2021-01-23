    public class UpperCaseDataGrid : DataGridView
    {
        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
            var txtBox = EditingControl as TextBox;
            if (txtBox != null)
                txtBox.CharacterCasing = CharacterCasing.Upper;
    
            base.OnEditingControlShowing(e);
        }
    }
