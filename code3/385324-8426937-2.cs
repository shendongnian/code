     public int GetSelectedIndex()
        {
             try
             {
               if(dataGridView2.SelectedRows.Count > 0)
               {
                  int selectedIndex = dataGridView2.CurrentRow.Index;
                  return selectedIndex;
               }
             }
             catch(Exception ex)
             {
              return 0;
             }
        }
