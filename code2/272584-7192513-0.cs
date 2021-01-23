     void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
            {
                foreach (DataGridViewColumn clm in dataGridView1.Columns)
                {
                    clm.SortMode = DataGridViewColumnSortMode.Automatic;  
                }
            }
