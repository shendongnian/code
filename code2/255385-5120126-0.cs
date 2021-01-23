    public class PersonViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    
        public string RoleId { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
