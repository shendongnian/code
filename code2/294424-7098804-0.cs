    public class User
    {
        public User(Guid? id = null, DateTime? created = null)
        {
            if (id != null)
                Id = id;
            if (created != null)
                Created = created;
        }
        public User()
        {
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? Created { get; internal set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; internal set; }
    }
