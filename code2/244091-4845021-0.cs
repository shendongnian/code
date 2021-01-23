    public class UserViewModel
    {
        [Required]
        public string UserName = { get; set; }
        [Required]
        public string FirstName = { get; set; }
        [Required]
        public string LastName = { get; set; }
    }
    public class SomeViewModel
    {
        public List<UserViewModel> Users { get; set; }
        public string SomeOtherProperty { get; set; }
    }
