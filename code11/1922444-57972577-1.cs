    public void Configure(EntityTypeBuilder<MovieProducer> builder)
    {
       builder.Entity<Movie>(entity => {
          entity.HasKey(m => m.Id);
          // ...
       });
       builder.Entity<Producer>(entity => {
          entity.HasKey(p => p.Id);
          // ...
       });
       builder.Entity<MovieProducer>(entity => {
          entity.HasKey(mp => new { mp.ProducerId , mp.MovieId });
          entity.HasOne(mp => mp.Producer)
                .WithMany(p => p.MovieProducers)
                .HasForeignKey(mp => mp.ProducerId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict or Cascade
          entity.HasOne(mp => mp.Movie)
                .WithMany(p => p.MovieProducers)
                .HasForeignKey(mp => mp.MovieId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict or Cascade
       });
    }
