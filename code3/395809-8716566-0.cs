    public class AuthenticatedPanel : Panel
    {
            public string Action { get; set; }
    
            public AuthenticatedPanel()
            {
                this.Load += new EventHandler(AuthenticatedPanel_Load);
            }
    
            void AuthenticatedPanel_Load(object sender, EventArgs e)
            {
    	         //your logic to check wether is user is legit or not 
                 // and then 
                 this.Visible = false;	
            }
     }
