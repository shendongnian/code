    HtmlGenericControl dl = new HtmlGenericControl("dl");
    dl.Attributes.Add("style", "overflow: hidden; font-size: small;");
    Page.Controls.Add(dl);
    HtmlGenericControl dt = new HtmlGenericControl("dt");
    dt.Attributes.Add("style", "float: left; width: 200px; etc.");
    dt.InnerText = "Apple:";
    dl.Controls.Add(dt);
