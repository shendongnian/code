    protected void Page_Load(object sender, EventArgs e)
    {
        CheckBox FieldCh = new CheckBox();
        FieldCh.ID = "Field_" + Field.Id;
        Panel1.Controls.Add(FieldCh);
        if (!IsPostBack)
        {
             // ....        
        }
    }
