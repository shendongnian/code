    private void btn_RemoveDuplicates_Click(object sender, EventArgs e)
    {
        var itemCollection = new List<string>();
        itemCollection.AddRange(lstbx_filefolder.Items);
        itemCollection.AddRange(lstbx_textfile.Items);
        
        var uniqueCollection = itemCollection.Distinct().ToList();
       // todo assign the values in the uniqueCollection to the source of the right listbox.
    }
