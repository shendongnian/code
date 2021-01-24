    protected void btnAdd0_Click(object sender, EventArgs e)
    {
      Button btnClicked = (Button)sender;
       string buttonId = btnClicked.ID;
       buttonId = Regex.Replace(buttonId, "[^0-9]+", string.Empty);
       int buttonRowIndex = 0;
       int.TryParse(buttonId, out buttonRowIndex);
       GridViewRow row = gridViewItems0.Rows[buttonRowIndex];
       TextBox txtCurrentQty = row.FindControl("txtQty" + buttonRowIndex) as TextBox;
       System.Diagnostics.Debug.WriteLine("ClientID: " + txtCurrentQty.ClientID);
       System.Diagnostics.Debug.WriteLine("Text: " + txtCurrentQty.Text);
    }
