    private void button1_Click(object sender, EventArgs e)
    {
        ToolTip toolTip1 = new ToolTip();
        toolTip1.Title = "Invalid entry"; // Title to display.
        toolTip1.Show("Please enter a number.", textBox1); // Message of the toolTip and to what control to appear.
    }
