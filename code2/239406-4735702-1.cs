    protected void Page_Load(object sender, EventArgs e)
    {
    	DataGrid dg = new DataGrid();
    	dg.DataSource = getModels();
    	dg.DataBind();
    }
    public List<EventDetail> getModels()
    {
    	var m = new List<EventDetail>();
    	for (int a = 0; a < 15; a++)
    	{
    		m.Add(new EventDetail() { prop1 = a, prop2 = string.Format("Prop2 {0}", a) });
    	}
    	return m;			        
    }
        
    public class EventDetail
    {
        public Int64 LogID { get; set; }
        public Object LogedObject { get; set; }
    }
