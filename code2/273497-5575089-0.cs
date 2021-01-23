    public List<Value> ValueList
    {
        get;
        set;
    }
    private void Form1_Load(object sender, EventArgs ev)
    {
        if (ValueList == null)
        {
            ValueList = new List<Value>();
        }
        dataGrid.DataSource = new BindingList<Value>(ValueList);
    }
