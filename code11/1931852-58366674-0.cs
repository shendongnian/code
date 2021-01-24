	class MyThing // Give it a better name matching its purpose
	{
	  public string Hash { get; set; }
	  public int Code { get; set; }
	  public string Subcode { get; set; }
	  public string Sign { get; set; }
	  public int Value { get; set; }
	}
	List<MyThing> myThingList = new List<MyThing>();
	myThingList.Add(new MyThing()
	{
	  Hash = Guid.NewGuid().ToString(),
	  Code = 2123345,
	  Subcode = "CS23",
	  Sign = "AWR",
	  Value = 30
	});
	myThingList.Add (new MyThing()
	{
	  Hash = Guid.NewGuid().ToString(),
	  Code = 5003345,
	  Subcode = "CS32",
	  Sign = "AWR",
	  Value = 15
	});
	myThingList.Add (new MyThing()
	{
	  Hash = Guid.NewGuid().ToString(),
	  Code = 2123345,
	  Subcode = "CS23",
	  Sign = "AWR",
	  Value = 5
	});
	myThingList.Add (new MyThing()
	{
	  Hash = Guid.NewGuid().ToString(),
	  Code = 2123345,
	  Subcode = "CS43",
	  Sign = "AWR",
	  Value = 15
	});
	var g = myThingList
	.GroupBy(t => new { t.Code, t.Subcode });
	// Select what you need from the group
