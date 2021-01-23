     protected void Page_Load(object sender, EventArgs e)
     {
            Label lbl = new Label();
            lbl.Text = "IT WORKS!";
            CustomPanel1.CheckBoxText = "Hide my innards!";
            CustomPanel1.InnerPanelControls.Add(lbl);
     }
