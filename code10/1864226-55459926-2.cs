cs
class AnimalJsonConverter : JsonConverter<Animal>
{
	public override void WriteJson(JsonWriter writer, Animal value, 
                                  JsonSerializer serializer)
	{
        throw new NotImplementedException();
	}
	public override Animal ReadJson(JsonReader reader, Type objectType, 
              Animal existingValue, bool hasExistingValue, JsonSerializer serializer)
	{
		var animalObj = JObject.Load(reader);
		var type = (string)animalObj["type"];
		Animal instance;
		switch (type)
		{
			case "Tiger":
				instance = new Tiger();
				break;
			case "Frog":
				instance = new Frog();
				break;
			default:
				instance = new Animal();
				break;
		}
		serializer.Populate(animalObj.CreateReader(), instance);
		return instance;
	}
}
