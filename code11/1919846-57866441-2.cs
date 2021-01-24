    // EF6 Syntax. EF Core will be a tad different /w IEntityTypeConfiguration<Student> implementation.
    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
       public StudentConfiguration()
       {
          HasMany(x => x.Subjects)
             .WithMany(x => x.Students)
             .Map(x => x.ToTable("StudentSubjects").MapLeftKey("StudentId").MapRightKey("SubjectId"));
       }
    }
