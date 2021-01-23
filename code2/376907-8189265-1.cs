    Panel1.Controls.Add(new LiteralControl("<td>"));
    if (required)
    {
        Mynewlabel.Text = lblname;
        Label lblRequired = new Label();
        lblRequired.Text = "*";
        lblRequired.CssClass= "required";
    }
    ControlsPanel.Controls.Add(Mynewlabel);
    ControlsPanel.Controls.Add(lblRequired);
    ControlsPanel.Controls.Add(new LiteralControl("</td>"));
