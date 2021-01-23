    [Serializable]
    public class Foo : ISerializable
    {
      // custom deserialization constructor]
      public Foo( SerializationInfo info , StreamingContext context )
      {
        //Get the values from info and assign them to the appropriate properties
      }
      public void GetObjectData( SerializationInfo info , StreamingContext context )
      {
        // populate info with appropriate key/value pairs.
        // Don't forget to explicitly serialize/deserialize and contained complex objects/structures
      }
    }
