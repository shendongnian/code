    public class Data1
    {
        public int Id { get; set; }
        public String Dep { get; set; }
        public int Sal { get; set; }
        public String JoinDate { get; set; }
    }
    public class Data2
    {
        public Data2()
        {
            Sal = new List<int>();
        }
        public List<int> Sal { get; set; }
        public String JoinDate { get; set; }
        public override string ToString()
        {
            return Sal.Aggregate(JoinDate, (current, s) => current + s.ToString());
        }
    }
