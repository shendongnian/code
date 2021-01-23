    HtmlControl divControl = new html HtmlGenericControl("div");
    divControl.Attributes.Add("id", lb.Items[i].Value);
    divControl.Visible = true; // Not really necessary
    this.Controls.Add(divControl);
    divControl.Controls.Add(new LiteralControl("<span>Put whatever <em>HTML</em> code here.</span>"));
