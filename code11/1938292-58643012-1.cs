C#
class AttributeBagConverter : JsonConverter<AttributeBag>
{
	public override bool CanConvert(Type typeToConvert)
	{
		return true;
	}
	public override AttributeBag Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException();
	}
	public override void Write(Utf8JsonWriter writer, AttributeBag value, JsonSerializerOptions options)
	{
		writer.WriteStartArray();
		
		if (value.Count > 0)
		{			
			foreach (var item in value)
			{
                writer.WriteStartObject();
				writer.WritePropertyName("Name");
				writer.WriteStringValue(item.Name);
				writer.WritePropertyName("Value");
				if (double.TryParse(item.Value.ToString(), out double n))
				{
					writer.WriteNumberValue(n);
				}
				else
				{
					writer.WriteStringValue(item.Value.ToString());
				}
                writer.WriteEndObject();
			}			
		}
		writer.WriteEndArray();
		writer.Flush();
	}
}
Then I decorated my AttributeBag class with `JsonConverter(typeof(AttributeBagConverter))`:
C#
[JsonConverter(typeof(AttributeBagConverter))]
public class AttributeBag: IEnumerable<Attribute>
{
	private readonly List<Attribute> attributes;
	public int Count 
	{ 
		get
		{
			return this.attributes.Count;
		}
	}
	public AttributeBag()
	{
		this.attributes = new List<Attribute>();
	}
	public AttributeBag Set(string name, object value)
	{
		var searchAttribute = this.attributes.Find(x => x.Name.Equals(name));
		if (searchAttribute != null)
		{
			searchAttribute.Value = value;
		}
		else
		{
			this.attributes.Add(new Attribute { Name = name, Value = value });
		}
		return this;
	}
	public Attribute Get(string name)
	{
		var searchAttribute = this.attributes.Find(x => x.Name.Equals(name));
		if (searchAttribute != null)
		{
			return searchAttribute;
		}
		else
		{
			throw new AttributeNameNotFoundException(name);
		}
	}
	public object GetValue(string name)
	{
		var searchAttribute = this.attributes.Find(x => x.Name.Equals(name));
		if (searchAttribute != null)
		{
			return searchAttribute.Value;
		}
		else
		{
			throw new AttributeNameNotFoundException(name);
		}
	}
	public IEnumerator<Attribute> GetEnumerator()
	{
		return this.attributes.GetEnumerator();
	}
	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
Calling JsonSerializer.Serialize() on the object now returns the correct JSON format that I was looking for!
