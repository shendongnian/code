    private void button1_Click(object sender, EventArgs e)
    {
        ColorDialog cd = new ColorDialog();
        if (cd.ShowDialog() == DialogResult.OK)
        {
            foreach (var panel in Controls.OfType<Panel>())
            {
                panel.BackColor = cd.Color;
            }
        }
    }
