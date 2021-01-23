    public void ParentControl_Init()
    {
        CustomUserControl tempControl = new CustomUserControl(); 
        this.Controls.Add(tempControl); 
        tempControl.Click += localClickEvent; 
    }
    
    public void localClickEvent(object sender, EventArgs e) 
    { 
        //do stuff 
    }  
