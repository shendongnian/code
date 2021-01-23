    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            lblResult.Text = (Double.Parse(txtFoot.Text + "," + txtInches.Text) * 0,39).ToString();
            lblFootAndInches.Text = txtFoot.Text + "'" + txtInches.Text + "\"";
        }
        catch (FormatException s)
        {
            //Do some exception handling here, like warning the viewer to enter a valid number.
        }
    }
  
