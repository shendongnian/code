    public MyUserControl()
    {
        CollapsiblePanelWidth = 105;
    }
    
    public int CollapsiblePanelWidth { get; set; }
    protected override void OnPreRender(EventArgs e)
    {
        DataDiv.Style[HtmlTextWriterStyle.Width] = CollapsiblePanelWidth.ToString();
        GridView1.Width = CollapsiblePanelWidth - 2;
    
        base.OnPreRender(e);
    }
