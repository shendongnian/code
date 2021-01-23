    protected void Page_Load(object sender,EventArgs e)
    {
        if(!IsPostBack)
        {
            ImgProduct.ImageUrl = FormatImageUrl("10");
        }
    }
    
    protected string FormatImageUrl(string s)
    {
        return "image"+s;
    }
