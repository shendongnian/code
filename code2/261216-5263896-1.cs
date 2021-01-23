    public override void DataBind()
    {
        var data = new string[] { "first", "second", "third" };
        this.ItemCount = data.Length;
        
        repeater.DataSource = data;
        repeater.DataBind();
    }
