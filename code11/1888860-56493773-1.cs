    public enum FilterOperatorEnum
    {
    	[Description("=")]
    	OPER_EQUAL = 0,
    	[Description("!=")]
    	OPER_NOT_EQUAL = 1,
    	[Description(">")]
    	OPER_MORE_THAN = 2,
    	[Description("<")]
    	OPER_LESS_THAN = 7,
    	[Description("InRange")]
    	OPER_IN_RANGE = 4,
    	[Description("OutRange")]
    	OPER_OUT_RANGE = 5
    }
    
    public class MyModel
    {
    	public int Id { get; set; }
    	public List<object> DropDownDataSource { get; set; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
    	if (!IsPostBack)
    		fillGrid();
    }
    
    private void fillGrid()
    {
    	var itemNames = Enum.GetNames(typeof(FilterOperatorEnum));
    	var dsDropDown = new List<object>();
    
    	for (int i = 0; i < itemNames.Length; i++)
    		dsDropDown.Add(new { Name = GetEnumDescription((FilterOperatorEnum)Enum.Parse(typeof(FilterOperatorEnum), itemNames[i])), Value = itemNames[i] });
    
    	var dataSource = new List<MyModel>
    	{
    		new MyModel() { Id = 1, DropDownDataSource = new List<object>(dsDropDown) },
    		new MyModel() { Id = 2, DropDownDataSource = new List<object>(dsDropDown) }
    	};
    
    	GridView1.DataSource = dataSource;
    	GridView1.DataBind();
    }
    
    public static string GetEnumDescription(Enum value)
    {
    	FieldInfo fi = value.GetType().GetField(value.ToString());
    	DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
    
    	return attributes != null && attributes.Length > 0
    		? attributes[0].Description 
    		: value.ToString();
    }
