        public class Pupil
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public string FavouriteLesson { get; set; }
        
            public SchoolEntity School { get; set; }
            public List<Teacher> Teachers { get; set; }
        }
        
        public class SchoolEntity
        {
            [Key]
            public int Id { get; set; }
            public bool DeepEnglishLearning { get; set; }
            public int? SchoolRating { get; set; }
        
            public List<Teacher> Teachers { get; set; }
            public List<Pupil> Pupils { get; set; }
        }
        
        public class Teacher
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Subject { get; set; }
        
            public SchoolEntity School { get; set; }
            public List<Pupil> Pupils { get; set; }
        }
    
        public class DatabaseContext : DbContext
        {
            public DatabaseContext(DbContextOptions<DatabaseContext> options)
                : base(options)
            {}
        
            public DbSet<SchoolEntity> SchoolTable { get; set; }
            public DbSet<Teacher> TeacherTable { get; set; }
            public DbSet<Pupil> PupilTable { get; set; }
        
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<SchoolEntity>().ToTable("School");
                modelBuilder.Entity<Teacher>().ToTable("Teacher");
                modelBuilder.Entity<Pupil>().ToTable("Pupil");
        
                modelBuilder.Entity<Teacher>().HasRequired(r => r.School).WithMany(m => m.Teachers).HasForiegnKey(k => k.Id);
                modelBuilder.Entity<Pupil>().HasRequired(r => r.School).WithMany(m => m.Pupils).HasForiegnKey(k => k.Id);
                //This will configure many-to-many with a join table. Use .Map to set the table name and key properties manually but EF will auto-name them if you dont
                modelBuilder.Entity<Teacher>().HasMany(x => x.Pupils).WithMany(x => x.Teachers); 
            }
        }
