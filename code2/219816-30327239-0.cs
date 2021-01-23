     private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                DataGridViewTextBoxEditingControl tb = e.Control as DataGridViewTextBoxEditingControl;
                tb.KeyDown -= dataGridView_KeyDown;
                tb.PreviewKeyDown -= dataGridView_PreviewKeyDown;
                tb.KeyDown += dataGridView_KeyDown;
                tb.PreviewKeyDown += dataGridView_PreviewKeyDown;
            }
        }
        void dataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                <your logic goes here>
            }
        }
