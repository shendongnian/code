    protected void Page_Load(object sender, EventArgs e)
    {
    	List<Reasons> reasonsList = new List<Reasons>()
    	{
    		new Reasons() { Code = "Code 1", Text = "Text 1" },
    		new Reasons() { Code = "Code 2", Text = "Text 2" },
    		new Reasons() { Code = "Code 3", Text = "Text 3" },
    	};
    
    	GridView1.DataSource = reasonsList;
    	GridView1.DataBind();
    }
    
    public class Reasons
    {
    	public string Text { get; set; }
    	public string Code { get; set; }
    }
