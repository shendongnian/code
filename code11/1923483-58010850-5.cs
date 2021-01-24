    string defaultConString = @"server=.\SQLExpress;Database=SampleDb;Trusted_Connection=yes;";
    
    void Main()
    {
    	var _context = new MyContext(defaultConString);
    	var result = from i in _context.Items
    				 select new
    				 {
    					 i.IdItem,
    					 i.Name,
    					 Quantity = i.States.Count(),
    					 Available = i.States.Count(x => x.IdStatus == 1)
    				 };
    
    	result.Dump(); // linqPad
    }
    
    
    public class MyContext : DbContext
    {
      public MyContext(string connectionString)
         : base(connectionString)
      { }
      public DbSet<Item> Items { get; set; }
      public DbSet<State> States { get; set; }
    }
    
    [Table("Items")]
    public partial class Item
    {
    	public Item()
    	{
    		this.States = new List<State>();
    		OnCreated();
    	}
    	[Key]
    	public virtual int IdItem { get; set; }
    	public virtual string Name { get; set; }
    	public virtual System.DateTime ImportDate { get; set; }
    	public virtual System.DateTime ReturnDate { get; set; }
    	public virtual IList<State> States { get; set; }
    	partial void OnCreated();
    }
    
    [Table("States")]
    public partial class State
    {
    	public State()
    	{
    		OnCreated();
    	}
    	[Key]
    	public virtual int IdState { get; set; }
    	public virtual string SmId { get; set; }
    	public virtual string Number { get; set; }
    	public virtual int IdItem { get; set; }
    	public virtual int IdStatus { get; set; }
    	public virtual Item Item { get; set; }
    
    	partial void OnCreated();
    }
