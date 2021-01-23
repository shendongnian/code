    protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack)
            {
               if(vartemp === vartemp2) //assuming that you want to set focus when specific condition meets
                 myButton1.Focus();
            }
        }
