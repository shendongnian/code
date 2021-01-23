    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string temp = this.Session["Captcha"].ToString();
        if (string.Compare(temp, this.txtCaptcha.Text.Trim()) == 0)
        {            
            // success logic
        }
        else
        {                     
            this.lblResult.Text = "Validation Text was not correct.";
            this.Session["Captcha"] = GenerateRandomCode();
            ImageCaptcha.ImageUrl = string.Format("~/BringImg.aspx?refresh={0}", Guid.NewGuid());
            ImageCaptcha.DataBind(); //This isn't necessary
        }
    }
