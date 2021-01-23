        void uxGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                 var item = uxGrid.Rows[e.RowIndex].DataBoundItem as NiftyThing;
                 if(item != null)
                 {
                     if(item.Property1)
                     {
                         e.CellStyle.SelectedBackColor = e.CellStyle.BackColor = Color.Red;
                         //Don't display 'True' or 'False'
                         e.Value = string.Empty;
                     }
                     else if(item.Property2)
                     ...
                 }      
            }
            catch { }
        }
