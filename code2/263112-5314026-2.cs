    public class def   {   public string materialcode{get;set;}   }
    public class abc
    {
        public string customername { get; set; }
        public List<def> DEF { get; set; }
    }
    List<abc> test1 = new List<abc>();
    List<def> test2 = new List<def>();
    test2.Add(new def() { materialcode = "something" });
    test1.Add(new abc() { customername = "anything", DEF = test2 });
    grdTest.DataSource = test1;
    grdTest.DataBind();
