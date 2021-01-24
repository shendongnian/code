    public class PartImageLink (
        public int Id { get; set; }
        public int PartId { get; set; }
        public int ImageId { get; set; }
        public virtual OePart OePart { get; set; }
        public virtual FinishedGoods FinishedGoods { get; set; }
        public virtual Image Image { get; set; }
    )
    public class FinishedGoodsMap
	{
		public FinishedGoodsMap(EntityTypeBuilder<FinishedGoods> entity)
		{
			entity.ToTable("FinishedGoods", schema: "dbo");
            entity.HasKey(e => e.Id);
            entity.HasMany(a => a.PartImageLinks).WithOne(b => b.FinishedGoods).HasForeignKey("PartId");
        }
	}
    public class OePartMap
	{
		public OePartMap(EntityTypeBuilder<OePartMap> entity)
		{
			entity.ToTable("OePart", schema: "dbo");
            entity.HasKey(e => e.Id);
            entity.HasMany(a => a.PartImageLinks).WithOne(b => b.OePartMap).HasForeignKey("PartId");
        }
	}
