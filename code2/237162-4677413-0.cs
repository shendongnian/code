    ToolTip btt= new ToolTip(); 
    
    btt.ToolTipTitle = "Tooltip"; 
    btt.UseFading = true; 
    btt.UseAnimation = true; 
    btt.IsBalloon = true; 
    btt.ShowAlways = true; 
    btt.AutoPopDelay = 5000; 
    btt.InitialDelay = 1000; 
    btt.ReshowDelay = 500; 
        
    
    btt.SetToolTip(button3, "Clicked."); 
