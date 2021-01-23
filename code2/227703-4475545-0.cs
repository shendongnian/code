    [Serializable]
    class Example : ISerializable {
       private static const int VERSION = 3;
       public Example(SerializationInfo info, StreamingContext context) {
          var version = info.GetInt32("Example_Version", VERSION);
          if (version == 0) {
             // Restore properties for version 0
          }
          if (version == 1) {
             // ....
          }
       }
       void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
           info.AddValue("Example_Version", VERSION);
           // Your data here
       }
    }
