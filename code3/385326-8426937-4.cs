     public int GetSelectedIndex()
        {
             int selectedIndex = 0;
             try
             {
               if(dataGridView2.SelectedRows.Count > 0)
               {
                  selectedIndex = dataGridView2.CurrentRow.Index;
               }
             }
             catch
             {
              return 0;
             }
          return selectedIndex;
        }
