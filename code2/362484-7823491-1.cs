    protected void Page_Load(object sender, EventArgs e)
    {
      // Here's the problem
      // this.Parent.Parent is a widget.ascx instance.
      // However, I cannot access the Widget class. I want to be able to do this
      // Widget widget = (Widget)(this.Parent.Parent);
      // DataTable table = widget.Records;
    
      IRecord record=this.Parent.Parent;
      DataTable table = widget.Records;
    }
