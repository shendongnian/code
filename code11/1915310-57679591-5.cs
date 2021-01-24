    private void button1_Click(object sender, EventArgs e)
    {
        foreach ( ListViewItem selectedItem in listView1.SelectedItems)
        {
            listView2.Items.Add(selectedItem);
            listView1.Items.Remove(selectedItem);  
        }
                
    }
 
   
