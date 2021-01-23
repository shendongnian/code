    Dictionary<string,TextBox> index = new Dictionary<string,TextBox>();
    index.add("Username",txtUsername);
    
    void setEnabled(string str, bool enable)
    {
        index[str].Enabled = enable;
    }
