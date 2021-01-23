    public class BaanAlternateItemAutoMappingOverride : IAutoMappingOverride<BaanAlternateItem>
    {
		public void Override(AutoMapping<BaanAlternateItem> mapping)
		{
			mapping.ReadOnly();
		
			mapping.Table("VIEW_BAAN_ALTERNATE_ITEMS");
		
			mapping.CompositeId<BaanAlternateItem>(x => x.Id) //are you mapping BaanAlternateItem right?
				.KeyProperty(x => x.ItemId, "ITEM_ID")
				.KeyReference(x => x.Item, "ALT_ITEM_ID");
		}
    }
