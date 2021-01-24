    FlowLayoutPanel panel = new FlowLayoutPanel();
    panel.FlowDirection = FlowDirection.TopDown;
    foreach (DataGridViewColumn column in dataGridView1.Columns)
    {
        panel.Controls.Add(new Label() { Text = column.HeaderText });
        panel.Controls.Add(new TextBox());                
    }
    this.Controls.Add(panel);
