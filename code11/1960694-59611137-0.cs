    public Order SelectedOrder
        {
            get
            {               
                return ViewState["StoredOrder"] == null ? (Order)ViewState["StoredOrder"] : null;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (SelectedOrder != null)
            {
                PanelCreator(SelectedOrder);
            }
        }
   
   
      protected void listviewselectedindexchanged(object sender, System.EventArgs e)
            {
             // I am not  sure how you got order in this event, you should use your version of code, but idea is the same
             ViewState["StoredOrder"] = sender as Order;
             PanelCreator(SelectedOrder);
            }
