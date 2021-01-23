    private void DoSomething(object state)
    {
        IList<string> excluedeFileTypes = (IList<string>)state;
    
        foreach(string fileType in excluedeFileTypes)                
            if (currentFiles[currentFileLoc].EndsWith(fileType))
                doNotCompare = true;
    }
    private IList<string> ExcludedFileTypes
    {
        get
        {
            List<string> filteTypes = new List<string>();
            foreach (var item in listBox1.SelectedItems)
                filteTypes.Add(item.ToString());
            return filteTypes;
        }
    }
