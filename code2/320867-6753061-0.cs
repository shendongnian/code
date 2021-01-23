    protected void ButtonHide_Click(object sender, EventArgs e)
    {
    
    Image tmp = (Image)FormView1.FindControl("ImageFP");
    tmp.Visible = !(tmp.Visible);// this will toggle the visibility 
    
    }
