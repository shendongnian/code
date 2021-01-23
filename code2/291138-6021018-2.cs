    foreach(var panel in Panels)
    {
        ContentPlaceHolder.Controls.Add(
            new LiteralControl("<fieldset class='step' Title='" + panel.Title + "'>"));
        ContentPlaceHolder.Controls.Add(panel);
        ContentPlaceHolder.Controls.Add(
            new LiteralControl("</fieldset>"));
    }
    base.Render(writer);
