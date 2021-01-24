    [Table("Styles")]
    public class Style : FullAuditedEntity
    {
        public virtual string Name { get; set; }
    
        public virtual string ShortName { get; set; }
    
        public ICollection<Style> Opposites { get; set; }
        public ICollection<Style> Alikes { get; set; }
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    
        modelBuilder.Entity<Style>()
                    .HasMany<Style>(s => s.Alikes)
                    .WithMany(c => c.Opposites)
                    .Map(cs =>
                            {
                                cs.MapLeftKey("OppositeId");
                                cs.MapRightKey("StyleId");
                                cs.ToTable("StyleXStyle");
                            });
    
    }
