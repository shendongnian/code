    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public StatusEnum Status { get; set; }
        public int StatusId { get; set; }
        [NotMapped]
        public string StatusName
        {
            get { return MyEnumHelper.GetDescription(Status); }
        }
    }
