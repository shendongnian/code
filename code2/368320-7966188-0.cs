    protected void Page_Load(object sender, EventArgs e)
    {
        pnlDynamic.Visible = false;     
        if (!this.IsPostBack)
        {       
            LoadProfiles();  //Data binding is done for radio button list
        }
        else
        {
            btnSubmit.Enabled = true;
        }
    
            GenerateProductUI(ProfileID); //DropDownLists are dynamically created and populated from database
            //ProfileID is the selected profile id
    }   
