    public abstract class Person
    {
        public int PersonId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
    public class Student : Person
    {
        [Column("RegisteredOn")]
        public DateTime RegisteredOnUtc { get; set; }
        public int Age { get; set; }
    }
    public class Teacher : Person
    {
        [Required]
        [MaxLength(50)]
        public string LessonName { get; set; }
    }
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            Map<Student>(x => x.Requires("IsStudent").HasValue(true));
            Map<Teacher>(x => x.Requires("IsStudent").HasValue(false));
        }
    }
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Configurations.Add(new PersonMap());
        }
        public void Detach(object entity)
        {
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;
            objectContext.Detach(entity);
        }
    }
