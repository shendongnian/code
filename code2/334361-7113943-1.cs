public void Serialize(MongoDB.Bson.IO.BsonWriter bsonWriter, Type nominalType, MongoDB.Bson.Serialization.IBsonSerializationOptions options)
{
	if (nominalType != typeof(IReagent) && nominalType != typeof(Reagent) && nominalType != typeof(Craft))
	{
		throw new ArgumentException("Cannot serialize anything but self");
	}
	bsonWriter.WriteStartDocument();
	bsonWriter.WriteInt32("ItemId", this.ItemId);
	bsonWriter.WriteInt32("Quantity", this.Quantity);
	if (this.Reagents != null)
	{
		bsonWriter.WriteName("Reagents");
		bsonWriter.WriteStartArray();
		foreach (var r in this.Reagents)
		{
			BsonSerializer.Serialize(bsonWriter, r.GetType(), r, options);
		}
		bsonWriter.WriteEndArray();
	}
	bsonWriter.WriteEndDocument();
}
