       private void button2_Click(object sender, EventArgs e)
            {
               for(int i = 0 ; i < listView1.SelectedItems.Count; i ++)
                   listView1.Items.Remove(listView1.SelectedItems[i]);
        
            }
