    protected override void Render(HtmlTextWriter writer)
    {
        var label = new HtmlGenericControl("span");
        label.InnerText = "Hello";
        label.RenderControl(writer);
        
        base.Render(writer);
    }
