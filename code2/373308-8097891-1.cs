    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        for (int i = 0; i < counter; i++)  
        {  
            MyControl ctrlMyControl = (MyControl)LoadControl("MyControl.ascx");  
            ctrlMyControl.ID = String.Format("ctrl_{0}", myPanel.Controls.Count); //count = 0
            myPanel.Controls.Add(ctrlMyControl); //count = 1
        }      
    }
