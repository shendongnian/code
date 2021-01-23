    public event EventHandler CustomCellValueChanged;
    protected override void OnDataSourceChanged(EventArgs e)
    {
        bs = this.DataSource as BindingSource;
    
        if (bs == null)
        {
            throw new ArgumentException("DataSource must be a BindingSource");
        }
    
        bs.ListChanged += new System.ComponentModel.ListChangedEventHandler(bs_ListChanged);
    
        base.OnDataSourceChanged(e);
    }
    void bs_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
    {            
        if (CustomCellValueChanged != null)
        {               
            CustomCellValueChanged(this, new EventArgs());
        }
    }
