    protected void DetailsView1_DataBound(object sender, EventArgs e)
    {
        Label objLabel = (Label)DetailsView1.FindControl("Label1");
        if (objLabel != null)
        {
            Decimal decValue = Convert.ToDecimal(objLabel.Text);
            if (decValue > 0)
            {
                objLabel.ForeColor = System.Drawing.Color.Green;
            }
            else if (decValue < 0)
            {
                objLabel.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
