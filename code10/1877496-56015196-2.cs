	public class LayerConfigurationConfiguration : IEntityTypeConfiguration<LayerConfiguration>
	{
		public void Configure(EntityTypeBuilder<LayerConfiguration> builder)
		{
			builder.HasKey(lc => lc.Id);
			/* ... */
			builder.Property(lc => lc.LayerConfig).HasConversion(
				v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
				v => JsonConvert.DeserializeObject<LayerConfig>(v)
			);
		}
	}
