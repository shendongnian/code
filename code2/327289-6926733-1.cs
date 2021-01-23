    public class Submition
    {
        public int ID { get; set; }
        public DateTime date { get; set; }
        public string SubmitionName { get; set; }
    
    
        public string SubmitionNameView
        {
            get
            {
                if (date <= DateTime.Now && SubmitionName == "-")
                    return "No Submission";
                else
                    return SubmitionName;
            }
            set
            {
                SubmitionName = value;
            }
        }
    }
