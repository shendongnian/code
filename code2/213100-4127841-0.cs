    protected void btnAdd_Click(object sender, EventArgs e)
    {
        lblResult.Text = (Double.Parse(txtFoot.Text + "," + txtInches.Text) * 0,39).ToString();
        lblFootAndInches.Text = txtFoot.Text + "'" + txtInches.Text + "\"";
    }
  
