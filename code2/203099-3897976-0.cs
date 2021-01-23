    Label l1 = new Label();
    Label l2 = new Label();
    Label l3 = new Label();
    Label l4 = new Label();
    l1.Text = "Name";
    l2.Text = "Color";
    l3.Text = "Quantity";
    l4.Text = "Notes";
    TextBox c1 = new TextBox();
    ComboBox c2 = new ComboBox();
    NumericUpDown c3 = new NumericUpDown();
    TextBox c4 = new TextBox();
    c2.Items.AddRange(new string[] { "Red", "Green", "Blue" });
    //tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
    //tableLayoutPanel1.AutoScroll = true;
    tableLayoutPanel1.AutoSize = true;
    tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
    tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
    int rowIndex = 0;
    tableLayoutPanel1.SuspendLayout();
    foreach (Control[] pair in new Control[][] {
       new Control[] {l1, c1},
       new Control[] {l2, c2},
       new Control[] {l3, c3},
       new Control[] {l4, c4}})
    {
       tableLayoutPanel1.Controls.AddRange(pair);
       if (tableLayoutPanel1.RowStyles.Count <= rowIndex)
          tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
       else
          tableLayoutPanel1.RowStyles[rowIndex++].SizeType = SizeType.AutoSize;
    }
    tableLayoutPanel1.ResumeLayout();
