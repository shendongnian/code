     private List<Flower> FlowerList 
        {
            get
            {
                 return(_FlowerList);
            }
            set
            {
                _FlowerList = value;
            }
    
        }
        protected List<Flower> _FlowerList = new FlowerList();
        protected void Page_Load(object sender, EventArgs e)
        {
           if (Session["FlowerList"]!= null) {
               FlowerList = (FlowerList)Session["FlowerList"];
           }
            if (!Page.IsPostBack)
            {
                FillRepeater();
            }
        }
