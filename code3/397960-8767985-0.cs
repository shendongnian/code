    public class User
    {
        public string DocumentId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public User()
        {
            Id = Guid.NewGuid();
        }
    }
    documentStore.Conventions.FindIdentityProperty = 
        prop => prop.DeclaringType == typeof (User) &&
                prop.Name == "DocumentId";
