    public IProgress<string> Progress{get;private set;}
    public CPLoader()
    {
        this.Progress=new Progress<string>(UpdateUI);
    }
    private void UpdateUI(string msg)
    {
        if(String.IsNullOrWhitespace(msg))
        {       
            this.DialogResult=DialogResult.Cancel;
            this.Close(); 
        }
        else
        {
            this.SomeLabel.Text=msg;
        }
    }
