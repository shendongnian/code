    protected void Page_Load(object sender, EventArgs e)
    {
        ImgProduct.DataBind();
        
    }
    protected void ImgProduct_DataBinding(object sender, EventArgs e)
    {
        ImgProduct.ImageUrl = "Image pathe + name";
    }
