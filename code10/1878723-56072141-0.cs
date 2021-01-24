    public class PersonViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        [BindNever]
        public IFormFile Photo { get; set; }
    }
