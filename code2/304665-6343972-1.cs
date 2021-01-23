    [Table("Enquiry")]
    public class Enquiry : ThreadItem
    {
        public string Comment { get; set;}
        [Column("ThreadItemID")]
        public ThreadItem ThreadItem {get; set;}
    }
