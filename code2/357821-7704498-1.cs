        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewComboBoxCell combo = this.dataGridView1[0, e.RowIndex] as DataGridViewComboBoxCell;
                   
                    if (e.RowIndex == 0)
                    {
                        //these data will be displayed in comboBox:
                         string[] data= {"item A1", "item B1", "item C1"};  
                        combo.DataSource = data;
                    }
                    if (e.RowIndex == 1)
                    {
                        //these data will be displayed in comboBox:
                        string[] data = {"item A2", "item B2", "item C2"};                        
                        combo.DataSource = data;
                    }
                    if (e.RowIndex == 2)
                    {
                        //these data will be displayed in comboBox:
                        string[] data = { "item A3", "item B3", "item C3" };                           
                        combo.DataSource = data;
                    }
                    
                }
            }
        }    
