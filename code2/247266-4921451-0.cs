    public string ExcludedFileType
    {
        get 
        {
            if (InvokeRequired)
                return (string)Invoke((Func<string>)delegate { return ExcludedFileType; });
    
            return (string)listBox1.SelectedItem; 
        }
    
        set
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { ExcludedFileType = value; });
                return;
            }
    
            listBox1.SelectedItem = value;
        }
    }
