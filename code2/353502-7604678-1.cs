    public class Role
    {
        public Role()
        {
           People = new HashSet<Person>();
        }
    
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Person> People { get; set; }
         //There is a many to many relationship to person
    }
