    public class MyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MyDTO[] Children { get; set; }
        public int Level { get; set; }
        public int? ParentId { get; set; }
    }
