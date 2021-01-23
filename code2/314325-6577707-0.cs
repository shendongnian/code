    public interface XmlSerializableEntity
    {
       XElement Serialize(); // or ToXml() if you prefer..
       void Deserialize(XElement e); // or Load() or something like that..
    }
