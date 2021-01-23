    public class Submition
    {
        public int ID { get; set; }
        public DateTime date { get; set; }
        public string SubmitionName { get; set; }
    
    
        public string SubmitionNameView
        {
            get
            {
                if (YourConditions)
                    return "Whatever you need";
                else
                    return SubmitionName;
            }
            set
            {
                SubmitionName = value;
            }
        }
    }
