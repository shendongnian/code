    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["timeout"] != null)
        {
            if (Request.QueryString["timeout"].ToUpper() == "Y")
            {
                SaveCart();
            }
        }
    }
    private void SaveCart()
    {
        lblResult.Text = "Cart Saved";
    }
