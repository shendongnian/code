    private void Form1_Load(object sender, EventArgs e)
    {
        listView1.KeyUp += new KeyEventHandler(ListView_KeyUp);
    }
    
    /// <summary>鍵盤觸發 ListView 清單</summary>
    private void ListView_KeyUp(object sender, KeyEventArgs e)
    {
        ListView ListViewControl = sender as ListView;
        if (e.KeyCode == Keys.Delete)
        {
            foreach (ListViewItem eachItem in ListViewControl.SelectedItems)
            {
                ListViewControl.Items.Remove(eachItem);
            }
    
        }
    }
