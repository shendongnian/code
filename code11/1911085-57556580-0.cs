        private Dictionary<string, int?> rcbSelection
        {
            get
            {
                if(this.ViewState["rcbSelection"] != null)
                {
                    return (Dictionary<string, int?>)this.ViewState["rcbSelection"];
                }
                return new Dictionary<string, int?>();
            }
            set
            {
                this.ViewState["rcbSelection"] = value;
            }
        }
Also in your page_load event if you don't want the dictionary to be reset after each postback consider removing ```rcbSelection = new Dictionary<string, int?>();``` from your page_load function or initializing only once by checking if it's the first page load by...
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                rcbSelection = new Dictionary<string, int?>();
            }
            // other postback code here ... 
        }
 
Hope that helps. 
