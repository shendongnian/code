	public sealed class EntityMap : ClassMap<Entity>
	{
		public EntityMap()
		{
			Table("Entities");
			Id(c => c.Id);
			Map(c => c.EntityName).CustomSqlType("nvarchar(50)").Not.Nullable();
			HasMany(c => c.Properties)
				.KeyColumn("EntityId")
				.AsMap<string>("PropertyName")
				.Component(part =>
				{
					part.Map(x => x.IntValue);
					part.Map(x => x.DecimalValue).Precision(12).Scale(6);
				});
		}
	}
