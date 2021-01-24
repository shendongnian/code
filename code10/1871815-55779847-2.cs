    public interface ITabUserControl
    {
        string DisplayName { get; set; }
    }
    public class MasterTechnicianViewModel : ITabUserControl
    {
        public string DisplayName { get; set; } = "Master Technician";
    }
    public class ServicesViewModel : ITabUserControl
    {
        public string DisplayName { get; set; } = "Services";
    }
