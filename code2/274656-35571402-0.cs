    //Your Page Load Event    
    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["s_event"] = "0"; // Initialize session variable
                BindData(); // Gridview Binding
            }
            
        } 
        
     protected void BindData()
        {
            if ((Session["s_event"].ToString())=="1")
            {
                cmdstr_ = (Session["search_item"].ToString());
            }
            else
            {
                cmdstr_ = ""; // Your command string to populate gridview
                
            }
            //        `enter code here`
        }
    
     protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["s_event"] = 1; // Search Event becomes 1.
             
            // Your Search Logic here
            
            Session["search_item"] = cmdstr;
            
            // Bind Gridview here
            
        }
