    public class Company
    {
        public Company() {
          Users = new Collection<User>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
