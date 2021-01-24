        protected void Page_Load(object sender, EventArgs e)
        {
        	if (!IsPostBack)
			{
				for(int i=1; i<10; i++) {
					numbers.Items.Add(new ListItem(i.ToString()));
				}
			}
		}
