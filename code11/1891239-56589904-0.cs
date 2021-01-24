    public class FullName
    {
        public String Name { get; set; }
        public String SurName { get; set; }
        public override string ToString()
        {
            return String.Format("{0} {1}", Name, SurName);
        }
    }
