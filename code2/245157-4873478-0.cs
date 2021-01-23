    <abc:MyControl runat="server" foo="This,Is,A,Test" />
    
    public string foo {
        get;
        set;
    }
    public string[] foos {
        get { return foo.Split(','); }
        //set; if needed
    }
