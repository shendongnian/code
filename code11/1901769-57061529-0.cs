lang-csharp
[Serializable]
public class SerializableObject : ISerializable
{
  public SerializableObject()
  {
  }
  public Dictionary<string, bool> Values = new Dictionary<string, bool>();
  public override bool Equals(object obj)
  {
     if (!(obj is SerializableObject other))
        return false;
     if (ReferenceEquals(this, obj))
        return true;
     if (Values.Count != other.Values.Count)
        return false;
     foreach (var kvp in Values)
        if (!other.Values.TryGetValue(kvp.Key, out var otherV) || kvp.Value != otherV)
           return false;
     return true;
  }
  public override int GetHashCode()
  {
     return 0;
  }
  public void GetObjectData(SerializationInfo info, StreamingContext context)
  {
     info.AddValue(KeyValuePairsKey, Values.Select(kvp => kvp).ToArray());
  }
  private SerializableObject(SerializationInfo info, StreamingContext context)
  {
     var kvps = info.GetValue(KeyValuePairsKey, typeof(KeyValuePair<string, bool>[])) as KeyValuePair<string, bool>[];
     foreach (var kvp in kvps)
     {
        Values.Add(kvp.Key, kvp.Value);
     }
  }
  private const string KeyValuePairsKey = "KVPS";
}
class Program
{
  static void Main(string[] args)
  {
     using (var stream = new MemoryStream())
     {
        var obj1 = new SerializableObject();
        obj1.Values["aaa"] = true;
        var obj2 = new SerializableObject();
        obj2.Values["bbb"] = false;
        var formatter = new BinaryFormatter();
        var dict = new Dictionary<SerializableObject, bool>
        {
           [obj1] = true,
           [obj2] = false
        };
        formatter.Serialize(stream, dict);
        stream.Seek(0, SeekOrigin.Begin);
        dict = (Dictionary<SerializableObject, bool>)formatter.Deserialize(stream);
     }
  }
}
