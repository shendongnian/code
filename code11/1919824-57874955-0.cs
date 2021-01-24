    BindingSource bs;
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        bs = new BindingSource();
        Debugger.Break();
        Binding b = new Binding("Text", bs, "Code", true, DataSourceUpdateMode.OnPropertyChanged);
        this.DataBindings.Add(b);
    }
