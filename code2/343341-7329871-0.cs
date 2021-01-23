    public class MyContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
               .HasMany(patient=> patient.Responses)
               .WithRequired(response => response.Patient)
               .HasForeignKey(response => response.PatientId)
               .WillCascadeOnDelete(true);
        }
    }
