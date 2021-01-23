        public class GenreConfiguration : EntityTypeConfiguration<Genre>
        {
            public GenreConfiguration()
                : base()
            {
                HasKey(p => p.GenreId);
                Property(p => p.GenreId).
                    HasColumnName("GenreId").
                    HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).
                    IsRequired();
                Property(p => p.Name).
                    HasColumnName("Name").
                    IsRequired();
                Ignore(p => p.Albums);
            }
        }
