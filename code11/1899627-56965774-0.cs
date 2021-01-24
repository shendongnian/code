     private void CheckItem(int id)
     {
         for (int i = 0; i < checkedListBox1.Items.Count; i++)
         {
             if ((checkedListBox1.Items[i] as ccBoxitem)?.val == id)
             {
                 checkedListBox1.SetItemChecked(i, true);
             }
         }
     }
