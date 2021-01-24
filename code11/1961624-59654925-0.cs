public long MoodId{ get; set; }
public Mood Mood { get; set; }
and change onModelCreating method to:
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
   base.OnModelCreating(modelBuilder);
   modelBuilder.Entity<AuthoredPhoto>()
      .HasOne(ap => ap.Mood)
      .WithMany(m => m.Photos)
      .HasForeginKey(ap => ap.MoodId)
      .OnDelete(DeleteBehavior.Cascade);
}
I hope this helps you.
