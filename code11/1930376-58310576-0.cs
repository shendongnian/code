//auditing works fine
var myEntity = await db.MyEntity.FindAsync(entityId);
myEntity.Property = newValue;
await db.SaveChangesAsync();
//auditing can't track the old value
var myEntity = new MyEntity();
db.Attach(myEntity);
myEntity.Property = newValue;
await db.SaveChangesAsync();
Here is the important bit of my auditing code for example
foreach (var entity in db.ChangeTracker.Entries())
{
	if(entity.State == EntityState.Detached || entity.State == EntityState.Unchanged)
	{
		continue;
	}
	var audits = new List<Audit>();
	//the typeId is a string representing the primary keys of this entity.
	//this will not be available for ADDED entities with generated primary keys, so we need to update those later
	string typeId;
	if (entity.State == EntityState.Added && entity.Properties.Any(prop => prop.Metadata.IsPrimaryKey() && prop.IsTemporary))
	{
		typeId = null;
	}
	else
	{
		var primaryKey = entity.Metadata.FindPrimaryKey();
		typeId = string.Join(',', primaryKey.Properties.Select(prop => prop.PropertyInfo.GetValue(entity.Entity)));
	}
	//record an audit for each property of each entity that has been changed
	foreach (var prop in entity.Properties)
	{
		//don't audit anything about primary keys (those can't change, and are already in the typeId)
		if(prop.Metadata.IsPrimaryKey() && entity.Properties.Any(p => !p.Metadata.IsPrimaryKey()))
		{
			continue;
		}
		//ignore values that won't actually be written
		if(entity.State != EntityState.Deleted && entity.State != EntityState.Added && prop.Metadata.AfterSaveBehavior != PropertySaveBehavior.Save)
		{
			continue;
		}
		//ignore values that won't actually be written
		if (entity.State == EntityState.Added && prop.Metadata.BeforeSaveBehavior != PropertySaveBehavior.Save)
		{
			continue;
		}
		//ignore properties that didn't change
		if(entity.State == EntityState.Modified && !prop.IsModified)
		{
			continue;
		}
		var audit = new Audit
		{
			Action = (int)entity.State,
			TypeId = typeId,
			ColumnName = prop.Metadata.SqlServer().ColumnName,
			OldValue = (entity.State == EntityState.Added || entity.OriginalValues == null) ? null : JsonConvert.SerializeObject(prop.OriginalValue),
			NewValue = entity.State == EntityState.Deleted ? null : JsonConvert.SerializeObject(prop.CurrentValue)
		};
	}
	//Do something with audits
}
