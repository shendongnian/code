    public class MyThing : MyBaseThing
    {
        public MyThing()
            : this(null, null)
        {
        }
        public MyThing(string pk, string rk)
            : base(pk, rk)
        {
            Status = "3";
        }
        public string Status { get; set; }
    }
