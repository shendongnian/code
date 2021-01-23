     protected override void OnInit(EventArgs e)
            {
                if (IsPostBack)
                {
                    //on postback ViewSate["test"] is null
                    ViewState["test"] = "Valuepostback";
                    //Now ViewSate["test"] is Valuepostback
    
                }
                base.OnInit(e);
            }
            protected override void OnLoad(EventArgs e)
            {
                if (IsPostBack)
                {
                    //on postback ViewState has been reloaded from the page sent and therefore the initial value set in the oninit does not exists anymore
                    //ViewState["test"] is MyValue
                    //if  you want to cahnge specifically the view state do it here
                }
    
                if (!IsPostBack)
                    ViewState["test"] = "MyValue";
    
                base.OnLoad(e);
            }
