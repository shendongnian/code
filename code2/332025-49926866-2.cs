    using System.Data.Entity;
    
    public class MyContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MemberCommentView> MemberComments { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            modelBuilder.Configurations.Add(new MemberConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            modelBuilder.Configurations.Add(new MemberCommentViewConfiguration());
    
            OnModelCreatingPartial(modelBuilder);
         }
    }
