    private List<string> myList = new List<string> {
    	"Serkan",
    	"Kadir"
    };
    private List<string> mySecondList = new List<string> {
    	"Istanbul",
    	"Ankara"
    
    };
    protected void Page_Load(object sender, System.EventArgs e)
    {
    	if (!Page.IsPostBack) {
    		if (myList.Count > 0) {
    			ListBox1.DataSource = myList;
    			ListBox1.DataBind();
    			ListBox1.Visible = true;
    		}
    	}
    }
    
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    	ListBox2.DataSource = mySecondList;
    	ListBox2.DataBind();
    
    	ListBox2.Visible = true;
    }
