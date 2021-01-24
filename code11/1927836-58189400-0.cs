    public class Group1 
    {
        public Group1( Group2 [] g2, String name)
        {
          Group2 = g2;
          Name = name;
        }
        public Group2[] Group2 { get; set; }
        public String Name {get;set;}
    }
    public class Group2
    {
        public Group2(int [] a, String name)
        {
          Values = a;
          Name = name;
        }
        public int[] Values;
        public String Name {get;set;}
    }
