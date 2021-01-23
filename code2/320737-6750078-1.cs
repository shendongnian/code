    protected override void RenderFieldForInput(HtmlTextWriter output)
    {
        var html = String.IsNullOrEmpty(Item[Field.InternalName] as string) ? "" : Item[Field.InternalName] as string;
        RenderHtmlForDisplay(output, html);
    }
