    public class SeasonConfiguration : EntityTypeConfiguration<Season>
    {
        internal SeasonConfiguration()
        {
            this.HasRequired(s => s.Show)
                .WithMany(tv => tv.Seasons)
                .HasForeignKey(s => s.TvShowId);
        }
    }
