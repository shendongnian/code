    public class SegmentationMap : EntityTypeConfiguration<Segmentation>
    {
        public SegmentationMap()
        {
        this.HasKey(t => t.Id);
        this.Property(t => t.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        this.ToTable("Segmentation");
        this.Property(t => t.Id).HasColumnName("Id");
        this.Property(t => t.TA).HasColumnName("TA");
        this.Property(t => t.HCPEID).HasColumnName("HCPEID");
        //it should be this.Property(t => t.SegmentationDisplay).HasColumnName("SegmentationDisplay"); 
        this.Property(t => t.SegmentationDisplay).HasColumnName("TerritoryCode"); 
        this.Property(t => t.SegmentationCalculate).HasColumnName("SegmentationCalculate");
        this.Property(t => t.SegmentationMRManual).HasColumnName("SegmentationMRManual");
        this.Property(t => t.SegmentationAdminChange).HasColumnName("SegmentationAdminChange");
        this.Property(t => t.SurveyId).HasColumnName("SurveyId");
        this.Property(t => t.TerritoryCode).HasColumnName("TerritoryCode");
        this.Property(t => t.YearMonth).HasColumnName("YearMonth");
        this.Property(t => t.Status).HasColumnName("status");
        this.Property(t => t.CreateBy).HasColumnName("create_by");
        this.Property(t => t.CreateDate).HasColumnName("create_date");
        this.Property(t => t.LastModifiedBy).HasColumnName("last_modified_by");
        this.Property(t => t.LastModifiedDate).HasColumnName("last_modified_date");
    }
}
