        using System;
        using System.Data.Entity;
        using System.Data.Entity.Infrastructure;
        using System.Data.Entity.ModelConfiguration;
        using System.Data.Objects;
        namespace ConsoleApplication5
        {
            public abstract class Person
            {
                public int PersonId { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
            }
            public class Student : Person
            {
                public DateTime RegisteredOnUtc { get; set; }
                public int Age { get; set; }
            }
            public class Teacher : Person
            {
                public string LessonName { get; set; }
            }
            public class PersonMap : EntityTypeConfiguration<Person>
            {
                public PersonMap()
                    : base()
                {
                    this.HasKey(t => t.PersonId);
                    this.Property(t => t.FirstName)
                        .IsRequired()
                        .HasMaxLength(50);
                    this.Property(t => t.LastName)
                        .IsRequired()
                        .HasMaxLength(50);
                    this.ToTable("Persons");
                    this.Property(t => t.PersonId).HasColumnName("PersonId");
                    this.Property(t => t.FirstName).HasColumnName("FirstName");
                    this.Property(t => t.LastName).HasColumnName("LastName");
                    this.Map<Student>(x => x.Requires("IsStudent").HasValue(true));
                    this.Map<Teacher>(x => x.Requires("IsStudent").HasValue(false));
                }
            }
            public class StudentMap : EntityTypeConfiguration<Student>
            {
                public StudentMap()
                    : base()
                {
                    this.Property(t => t.RegisteredOnUtc).HasColumnName("RegisteredOn");
                }
            }
            public class TeacherMap : EntityTypeConfiguration<Teacher>
            {
                public TeacherMap()
                    : base()
                {
                    this.Property(t => t.LessonName)
                        .IsRequired()
                        .HasMaxLength(50);
                    this.Property(t => t.LessonName).HasColumnName("Lesson");
                }
            }
            public class PersonContext : DbContext
            {
                public ObjectContext ObjectContext
                {
                    get
                    {
                        return ((IObjectContextAdapter)this).ObjectContext;
                    }
                }
                public DbSet<Person> Persons { get; set; }
                public DbSet<Student> Students { get; set; }
                public DbSet<Teacher> Teachers { get; set; }
                protected override void OnModelCreating(DbModelBuilder modelBuilder)
                {
                    modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
                    modelBuilder.Configurations.Add(new PersonMap());
                    modelBuilder.Configurations.Add(new StudentMap());
                    modelBuilder.Configurations.Add(new TeacherMap());
                }
                public void Detach(object entity)
                {
                    var objectContext = ((IObjectContextAdapter)this).ObjectContext;
                    objectContext.Detach(entity);
                }
            }
            public class Program
            {
                static void Main()
                {
                    var personContext = new PersonContext();
                    personContext.Database.Delete();
                    personContext.Database.Create();
                }
            }
        }
