    tableLayoutPanel1.AutoScroll = true;
    tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
    tableLayoutPanel1.RowStyles.Clear();
    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 150));
    for (int i = 0; i < 4; i++) {
      AddTextBox("TextBox #" + i.ToString());
    }
    private void AddTextBox(string info) {
      TextBox tx = new TextBox();
      tx.Multiline = true;
      tx.Text = info;
      tx.ScrollBars = ScrollBars.Vertical;
      tx.WordWrap = true;
      tx.Height = 150;
      tx.Anchor  = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
      tableLayoutPanel1.Controls.Add(tx);
    }
