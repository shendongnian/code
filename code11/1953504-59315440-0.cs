    public class MyTable
    {
        [Key]
        public int UnicId { get; set; }
        public string Name { get; set; }
    }
    public class SecondTable
    {
        [Key]
        public int Id { get; set; }
        public int UnicId { get; set; }
        public string Names { get; set; }
    }
    public class NewTable
    {
        public int UnicId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Names { get; set; }
    }
