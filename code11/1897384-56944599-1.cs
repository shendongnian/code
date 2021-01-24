    private void ListBox_Drop(object sender, DragEventArgs e)
        {
            string name = (string)e.Data.GetData("Name");
            string path = (string)e.Data.GetData("Path");
        }
