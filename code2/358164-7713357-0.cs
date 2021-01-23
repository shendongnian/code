    protected void Page_Load()
    {
      Button ButtonChange = new Button();
    
      ButtonChange.Text = "Change";
      ButtonChange.ID = "change_" + i.ToString();
      ButtonChange.Font.Size = FontUnit.Point(7);
      ButtonChange.ControlStyle.CssClass = "button";
      ButtonChange.Click += new EventHandler(test);
    }
