       //designing a checkbox inside datagrid
                                   <DataGridTemplateColumn Header="{StaticResource _status}" Width="Auto">
                                        <DataGridTemplateColumn.CellTemplate>
                                            <DataTemplate>
                                                <CheckBox x:Name="chk" Click="Click_SelectionChanged_1"/>                
                                            </DataTemplate>
                                        </DataGridTemplateColumn.CellTemplate>
                                    </DataGridTemplateColumn>
         void Click_SelectionChanged_1(....)
         {
           CheckBox c=(CheckBox)sender;
           bool _stat=c.IsChecked;
          
             using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("UPDATE tableStudent SET Status="+_stat+" WHERE id="+_dbid, con))
                    {
                        command.ExecuteNonQuery();
                    }
                    con.Close();
                }
         }  
        int _dbid=-1; 
       //get selected id from datagrid selection change
        void datagrid_SelectionChange(.....)
        {
                    DataRowView row = (DataRowView)t_bill_itemsDataGrid.SelectedItems[0];
                    string s = row["id"].ToString();
                    _dbid = int.Parse(s);
        }
        
