    public class SegmentSet
    {
        public long SegmentSetId { get; set; }
        // ...
        public virtual SegmentSetGeometry Geometry { get; set; }
    }
    public class SegmentSetGeometry
    {
        public long SegmentSetId { get; set; }
        // ...
        public virtual SegmentSet SegmentSet { get; set; }
    }
    public class SegmentSetConfiguration: EntityTypeConfiguration<SegmentSet>
    {
        public SegmentSetConfiguration()
        {
            ToTable("SegmentSets");
            HasKey(x => x.SegmentSetId);
            // Note: Do not map the HasOptional here... Only map the required on the other side.
        }
    }
    public class SegmentSetGeometryConfiguration : EntityTypeConfiguration<SegmentSetGeometry>
    {
        public SegmentSetGeometryConfiguration()
        {
            ToTable("SegmentSetGeometries");
            HasKey(x => x.SegmentSetId);
            HasRequired(x => x.SegmentSet)
                .WithOptional(x=>x.Geometry);
        }
    }
