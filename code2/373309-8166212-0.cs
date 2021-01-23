    protected override void Page_Load(object sender, EventArgs e)
    {
        int counter;
        if (Session["counter"] == null)
        {
            counter = 0;
        }
        else
        {
            counter = (int)Session["counter"];
        }
        for (int i = 0; i < counter; i++)  
        {  
            MyControl ctrlMyControl = (MyControl)LoadControl("MyControl.ascx");  
            ctrlMyControl.ID = String.Format("ctrl_{0}", myPanel.Controls.Count); //count = 0
            myPanel.Controls.Add(ctrlMyControl); //count = 1
        }      
    }
