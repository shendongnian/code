    public class ForCommentEntities:EntityTypeConfiguration<Comment> {
        public ForCommentEntities(String schemaName) {
            this.HasRequired(e => e.SystemUser)
                .WithMany()
                .Map(m => m.MapKey("SystemUserID"));
            this.Ignore(e => e.Remarks);
            this.ToTable("Comment", schemaName);
        }
    }
