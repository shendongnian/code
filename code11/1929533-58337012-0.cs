               //hope it helps
                DataRowView dataRow = (DataRowView)tbl_perDataGrid.SelectedItem;
                //if multiple selection
                DataRowView row = (DataRowView)t_datagrid.SelectedItems[0];
                string s = row["name"].ToString();
                ----------------------------------------more useful code for working with DataRowView	
                ///getting column
                	int i = (int)((DataRowView)t_datagrid.SelectedItems[0])["id"];
                ///with indexes
                	//-------------------------------------
                    DataGridRow row1 = e.Row;
                    int row_index = ((DataGrid)sender).ItemContainerGenerator.IndexFromContainer(row1);
                    int numberOfColumns = ((DataGrid)sender).Columns.Count;
                    
                    //-----------------------------------
                   
