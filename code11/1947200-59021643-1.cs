    private void btnAddControl_Click(object sender, EventArgs e)
    {
        tableLayoutPanel1.Controls.Add(new TextBox() {
            Multiline = true, Text = "TextBox from Button", Dock = DockStyle.Fill }, currentCell.Y, currentCell.X);
    }
    // Each ToolStripMenuItem sub-item subscribes to the event using this handler
    private void contextTLPMenu_Clicked(object sender, EventArgs e)
    {
        Control ctl = null;
        switch ((sender as ToolStripMenuItem).Text)
        {
            case "TextBox":
                ctl = new TextBox() { Multiline = true, Text = "TextBox from ContextMenu" };
                break;
            case "Button":
                ctl = new Button() { Text = "A Button", ForeColor = Color.White };
                break;
            case "Panel":
                ctl = new Panel() { BackColor = Color.LightGreen };
                break;
            default:
                break;
        }
        if (ctl != null) {
            ctl.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(ctl, currentCell.Y, currentCell.X);
        }
    }
