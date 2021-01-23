    protected override void OnLoad(EventArgs e)
    {
       var profile = GetProfile();
    
       LiteralControl ctl = new LiteralControl(@"
         <style>
             .UserStyleA 
             { 
                background-color: " + profile.BackgroundColor + @";
                color: " + profile.ForeColor + @";
         </style>");         
    }
