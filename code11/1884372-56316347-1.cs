    public class Technician
    {
        int Id { get;set; }
    }
    
    public class Client
    {
        int Id { get; set; }
        int TechnicianId { get; set; }
        public virtual Technician Technician {get; set;}
        public string Name { get; set; }
    }
