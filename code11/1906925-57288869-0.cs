    private void listView2_ItemCheck(object sender, ItemCheckEventArgs e)
    {
    	listView2.BeginUpdate();
        foreach (ListViewItem item in listView2.Items)
        {
    
        }
    
       if (e.CurrentValue == CheckState.Unchecked  &&          
       listView2.Items[e.Index].SubItems[0].Text == ("Colleen"))
            {
                Form2 f2 = new Form2();
                f2.Show();
            }        
    
              else if (e.CurrentValue == CheckState.Checked)
              {
    
              }
    	listView2.EndUpdate();
     }
