    private void PopulateListView()
    { 
        string directoryPath=Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        String[] files=System.IO.Directory.GetFiles(directoryPath);
        if(files!=null)
        {
            foreach(string file in files)
            {
                listView1.Items.Add(new ListViewItem(file));
            }
        }
    }
    private void listView1_MouseDown(object sender, MouseEventArgs e)
    {
        System.Collections.Specialized.StringCollection filePath = new
        System.Collections.Specialized.StringCollection();
        if (listView1.SelectedItems.Count > 0)
        { 
            filePath.Add(listView1.SelectedItems[0].Text);
            DataObject dataObject = new DataObject();
            dataObject.SetFileDropList(filePath);
            listView1.DoDragDrop(dataObject, DragDropEffects.Copy);
        }
    }
