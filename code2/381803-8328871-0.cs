    public class Prog
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        // ..
        public ProgStatus Status
        {
            get
            {
                if (Date != null)
                    return ProgStatus.Date;
                if (Name != null)
                    return ProgStatus.Name;
                // ..
            }
        }
    }
