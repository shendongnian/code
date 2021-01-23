    public class DataGridViewNoEnter : DataGridView
    {       
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((Form)this.TopLevelControl).DialogResult = DialogResult.OK;
                return false;
            }
            return base.ProcessDataGridViewKey(e);
        }      
    }
