    public class House
    {
        [Key]
        public int Id { get; set; }
        private IEnumerable<HouseFeature> HouseFeatures { get; set; }
        public ICollection<int> FeatureIds
        {
            get { return HouseFeatures.Select((hf) => hf.FeatureId).ToList(); }
        }
    }
    class HouseFeatureConfiguration : IEntityTypeConfiguration<HouseFeature>
    {
        public void Configure(EntityTypeBuilder<HouseFeature> builder)
        {
            builder.HasKey(nameof(HouseFeature.FeatureId), nameof(HouseFeature.HouseId));
            builder
                .HasOne<House>()
                .WithMany("HouseFeatures") // can't use nameof or expression because it's private member of the House
                .HasForeignKey(nameof(HouseFeature.HouseId));
            builder
                .HasOne<Feature>()
                .WithMany()
                .HasForeignKey(nameof(HouseFeature.FeatureId));
        }
    }
