    protected override void CreateChildControls()
    {
        // Add a LiteralControl to the current ControlCollection.
        this.Controls.Add(new LiteralControl("<h3>Value: "));
        // Create a text box control, set the default Text property, 
        // and add it to the ControlCollection.
        TextBox box = new TextBox();
        box.Text = "0";
        this.Controls.Add(box);
        this.Controls.Add(new LiteralControl("</h3>"));
    }
