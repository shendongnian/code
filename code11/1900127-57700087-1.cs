      private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
            {
                if (e.KeyData == Keys.Delete)
                {
    
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this row, it will permanently delete the data", "Delete?", MessageBoxButtons.YesNo);
    
                    if (dialogResult == DialogResult.Yes)
                    {
                        ColumnView view = gridControl1.FocusedView as ColumnView;
                        view.CloseEditor();
    
                        {
                            Delete();
                            view.UpdateCurrentRow();
    
                            product_viewTableAdapter1.Fill(allDataSets1.Product_view);
                        }
                    }
    
                }
            }
