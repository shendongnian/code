    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    
    public class MemberConfiguration : EntityTypeConfiguration<Member>
    {
        public MemberConfiguration()
        {
            HasKey(x => x.MemberID);
            Property(x => x.MemberID).HasColumnType("int").IsRequired();
            Property(x => x.FirstName).HasColumnType("varchar(512)");
            Property(x => x.LastName).HasColumnType("varchar(512)")
            // configure many-to-many through internal EF EntitySet
            HasMany(s => s.Comments)
                .WithMany(c => c.Members)
                .Map(cs =>
                {
                    cs.ToTable("MemberComment");
                    cs.MapLeftKey("MemberID");
                    cs.MapRightKey("CommentID");
                });
        }
    }
    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            HasKey(x => x.CommentID);
            Property(x => x.CommentID).HasColumnType("int").IsRequired();
            Property(x => x.Message).HasColumnType("varchar(max)");
        }
    }
    public class MemberCommentViewConfiguration : EntityTypeConfiguration<MemberCommentView>
    {
        public MemberCommentViewConfiguration()
        {
            ToTable("MemberCommentView");
            HasKey(x => new { x.MemberID, x.CommentID });
            
            Property(x => x.MemberID).HasColumnType("int").IsRequired();
            Property(x => x.CommentID).HasColumnType("int").IsRequired();
            Property(x => x.Something).HasColumnType("int");
            Property(x => x.SomethingElse).HasColumnType("varchar(max)");
            // configure one-to-many targeting the Join Table view
            // making all of its properties available
            HasRequired(a => a.Member).WithMany(b => b.MemberComments);
            HasRequired(a => a.Comment).WithMany(b => b.MemberComments);
        }
    }
