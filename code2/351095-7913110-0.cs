    public partial class Form1 : Form
    {
    	public Form1()
    	{
    		InitializeComponent();
    	}
    
    	public class Alert
    	{
    		public string Alias { get; set; }
    		public int ServiceHours { get; set; }
    		public int TotalHoursDone { get; set; }
    		public int UserId { get; set; }
    		public int VehicleId { get; set; }
    	}
    
    	private static readonly List<Alert> AlertsToDo = new List<Alert>();
    
    	private void button1_Click(object sender, EventArgs e)
    	{
    		var rng = new Random();
    
    		var watch = new System.Diagnostics.Stopwatch();
    		watch.Start();
    		for (int i = 0; i < 1000000; i++)
    		{
    			int random = rng.Next();
    
    			AlertsToDo.Add(new Alert
    			{
    				Alias = random.ToString(),
    				UserId = random
    			});
    		}
    		Console.WriteLine(@"Random generation: {0}", watch.ElapsedMilliseconds);
    
    		watch = new System.Diagnostics.Stopwatch();
    		watch.Start();
    		var alertsGrouped = AlertsToDo.Select(a => a.UserId)
    							  .Distinct()
    							  .ToDictionary(userId => userId,
    					userId => AlertsToDo.Where(a => a.UserId == userId)
    										.OrderBy(a => a.Alias)
    										.ToList());
    		watch.Stop();
    		Console.WriteLine(@"Mine: {0}", watch.ElapsedMilliseconds);
    		Console.WriteLine(alertsGrouped.Count);
    
    		watch = new System.Diagnostics.Stopwatch();
    		watch.Start();
    		alertsGrouped = AlertsToDo.GroupBy(a => a.UserId)
    				  .ToDictionary(g => g.Key,
    								g => g.OrderBy(a => a.Alias).ToList());
    		watch.Stop();
    		Console.WriteLine(@"Ahmad's: {0}", watch.ElapsedMilliseconds);
    		Console.WriteLine(alertsGrouped.Count);
    	}
    }
