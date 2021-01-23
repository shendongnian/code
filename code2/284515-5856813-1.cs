        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
           {
              ddl1.Items.Insert(0, new ListItem("-Choose car-", "-Choose car-"  ));
           }
        
            ddl1.SelectedIndex = 0;
        }
