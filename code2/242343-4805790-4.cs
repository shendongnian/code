    public class ApplicationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ApplicationInstanceDto
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("ApplicationId")]
        public ApplicationDto Application { get; set; }
        [ForeignKey("CustomerId")]
        public CustomerDto Customer { get; set; }
    } 
