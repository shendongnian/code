    Control control = this.FindControl("body");
    HtmlControl divControl = new HtmlGenericControl("div");
    divControl.Attributes.Add("id","myid");
    divControl.Attributes.Add("class","myclass");
    control.Controls.Add(divControl);
