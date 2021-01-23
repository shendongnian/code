    Literal l = new Literal();
    l.Text = "bob";
    
    HtmlControl divControl = new HtmlGenericControl("div");
    divControl.Attributes.Add("id", "someId");
    divControl.Visible = true;
    divControl.Controls.Add(l);
    
    this.Controls.Add(divControl);
