        HtmlGenericControl style = new HtmlGenericControl("link");
        style.Attributes.Add("href", "path-to-your-style");
        style.Attributes.Add("rel", "stylesheet");
        style.Attributes.Add("type", "text/css");
        this.Page.Header.Controls.AddAt(0, style);
