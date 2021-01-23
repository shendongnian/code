    private void AddTLP()
    {
      List<string> headers = new List<string>();
      headers.Add("Column 1");
      headers.Add("Column 2");
      headers.Add("Column 3");
        
      TableLayoutPanel tlp = new TableLayoutPanel();
      tlp.Size = new Size(356, 120);
      tlp.BackColor = Color.Gray;
        
      for (int i = 0; i < headers.Count; i++)
      {
        Label l = new Label();
        l.Text = headers[i].ToString();
       
        ColumnStyle cStyle = new ColumnStyle(SizeType.AutoSize);
        tlp.ColumnStyles.Add(cStyle);
        tlp.Controls.Add(l, i, 0);
      }
        
      tlp.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
      
      // Add controls to test growth:
      tlp.Controls.Add(new Button(), 0, 1);
      tlp.Controls.Add(new TextBox(), 1, 2);
        
      this.Controls.Add(tlp);
    }
