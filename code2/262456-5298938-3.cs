    listView1.Items[0].Selected = true;
    listView1.Select();
    int c =listView1.SelectedItems.Count;
    MessageBox.Show(c + ": and : " + listView1.Items[0].ToString());
    //  Thread.Sleep(3000);
    method();  
