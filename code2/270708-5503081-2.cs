    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? WorkedYears { get; set; }
        [NotMapped]
        public int WorkedYearsDisplay
        {
            get
            {
                return WorkedYears ?? 0;
            }
            set
            {
                WorkedYears = value == 0 ? new Nullable<int>() : value;
            }
        }
    }
