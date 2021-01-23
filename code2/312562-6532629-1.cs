    protected void Page_Load(object sender, EventArgs e)
        {
           if (!Page.IsPostBack)
           {   
    
            newBTN = new Button();
            newBTN.Text = "Button 1";
    
    
            gm = new GenerateMe(PlaceHolder1, newBTN);
            gm.ExecuteAll();       
            Response.Write(gm.ResponseWrite());
           }
        }
