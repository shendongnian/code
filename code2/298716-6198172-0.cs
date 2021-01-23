    protected override void Render(HtmlTextWriter writer)
    {
        if (string.IsNullOrEmpty(base.Text))
        {
            Text = (this.DefaultText ?? string.Empty);
        }
        base.Render(writer);
    }
