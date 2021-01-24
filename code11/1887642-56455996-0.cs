    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<TaskCategory> TaskCategories { get; set; }
    }
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<TaskCategory> TaskCategories { get; set; }
    }
    public class TaskCategory
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
       //DbContext
        public DbSet<Task> Task { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<TaskCategory> TaskCategory { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskCategory>()
                .HasKey(t => new { t.CategoryId, t.TaskId });
            modelBuilder.Entity<TaskCategory>()
                .HasOne(pt => pt.Category)
                .WithMany(p => p.TaskCategories)
                .HasForeignKey(pt => pt.CategoryId);
            modelBuilder.Entity<TaskCategory>()
                .HasOne(pt => pt.Task)
                .WithMany(t => t.TaskCategories)
                .HasForeignKey(pt => pt.TaskId);
        }
