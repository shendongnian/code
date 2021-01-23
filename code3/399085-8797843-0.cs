        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindGrid();
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // Note that this is for debug purposes only. Production code should log 
                // this exception somewhere so that it can be observed and dealt with
            }
        }
        private void BindGrid()
        {
            MasterCust.DataSource = BAL.Load();
            MasterCust.DataBind();
        }
