    List<HiddenField> HiddenFields = new List<HiddenField>{};
    List<TextBox> TextBoxs = new List<TextBox>{};
    List<LiteralControl> LiteralControls = new List<LiteralControl>{};
    
    
    OTD.Controls.Add(OtherDescAddControl(OtherPlaceHolder, hItemId, ltcItem, txtItem));
    // do this for all your items that you load to page (add them to your list).
    HiddenFields.Add(hItemId);
    // when you are done with loading all your controls to page, add your populated Lists                        to session. 
    Session["HiddenFields"] = HiddenFields;
    
    
    //On Page_Init or Page_Load, simpy load them back IF **page is postback**.
    If(Page.IsPostBack)
    {
        LoadControlsFromSession();
    }
    private void LoadControlsFromSession()
    {
        HiddenFields = Session["HiddenFields"] as List<HiddenFields>;
        // Load all your List objects from session like above.
        int counter = 0;
        if(HiddenFields != null)
        {
            foreach(HiddenField hdnField in HiddenFields)
            {
                //load your objects with the same method you have from your List.
                OTD.Controls.Add(OtherDescAddControl(OtherPlaceHolder, HiddenFields[counter], LiteralControls[counter], TextBoxs[counter]));
                counter++;
            }
        }
    }
