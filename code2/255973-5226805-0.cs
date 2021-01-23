    public class FilterViewModel
    {
        public string ClientName { get; set; }
        public string PhysicianName { get; set; }
        public IEnumerable<SelectListItem> ClientNames { get; set; }
        public IEnumerable<SelectListItem> PhysicianNames { get; set; }
    }
