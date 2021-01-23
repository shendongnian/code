    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        for (int i = 0; i < counter; i++)  
        {  
            MyControl ctrlMyControl = (MyControl)LoadControl("MyControl.ascx");  
            ctrlMyControl.SetID(i);  
            myPanel.Controls.Add(ctrlMyControl);  
        }      
    }
