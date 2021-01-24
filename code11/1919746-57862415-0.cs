    public class Staff
    {
        public int Id { get; set; }
        public virtual Project Project { get; set; }
    }
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
    }
