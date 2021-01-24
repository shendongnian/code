    private void ButtonSearch_Click(object sender, EventArgs e)
    {
         panelYellow.Height = buttonSearch.Height;
         panelYellow.Top = buttonSearch.Top;
         searchPanel.getInstance().Visible = true;
         this.Controls.Add(searchPanel.getInstance()); // add this line
    }
