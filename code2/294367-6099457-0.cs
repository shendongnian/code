    protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["ItemSetup"] == null)
			{
				_ItemSetup = new ItemSetup();
				Session["ItemSetup"] = _ItemSetup;
			}
			_ItemSetup = Session["ItemSetup"] as ItemSetup;
			_ItemSetup.ItemTypeChanged += _ItemSetup_ItemTypeChanged;
    
            if (!IsPostback){
                // Do something else
            }
		}
