var result = new Dictionary<string, string>();
var assembly = Assembly.GetExecutingAssembly();
var resourceName = "MyProgram.Resources.MyDictionary.bin";
using (Stream stream = assembly.GetManifestResourceStream(resourceName))
using (BinaryReader reader = new BinaryReader(stream))
  {
    int count = reader.ReadInt32();
    for (int i = 0; i < count; i++)
      {
        string key = reader.ReadString();
        string value = reader.ReadString();
        result[key] = value;
      }
  }
