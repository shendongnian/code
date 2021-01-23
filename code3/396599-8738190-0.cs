    void Page_Load(...)
    {
         if (!Page.IsPostback)
         {
              IAgreeImageButton.ImageUrl = ResourceManager.GetImageCDN("iagree.png");
         }
    }
