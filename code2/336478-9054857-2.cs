    public string __ad1ImageUrl = "";
    public string __ad2ImageUrl = "";
    public string __ad3ImageUrl = "";
    public string __ad4ImageUrl = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            __ad1ImageUrl = "UserControls/Images/mainBanner1.jpg";
            __ad2ImageUrl = "UserControls/Images/mainBanner2.jpg";
            __ad3ImageUrl = "UserControls/Images/mainBanner3.jpg";
            __ad4ImageUrl = "UserControls/Images/mainBanner4.jpg";
        }
    }
