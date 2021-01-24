    public class GymContext : DbContext
    {
        public GymContext(DbContextOptions<GymContext> options) : base(options) { }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<TrainingPlan> TrainingPlans { get; set; }
        public DbSet<TrainingPlanExercise> TrainingPlanExercises { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainingPlanExercise>()
                .HasKey(e => new { e.ExerciseId, e.TrainigPlanId });
            modelBuilder.Entity<TrainingPlanExercise>()
                .HasOne(x => x.TrainigPlan)
                .WithMany(x => x.Exercises)
                .HasForeignKey(x => x.TrainigPlanId);
         }
    }
