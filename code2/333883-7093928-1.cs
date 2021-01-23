    public class Example
    {
      static void Main()
      {
         using (Stream s = File.OpenRead("myfile.xml"))
         {
            Items myItems = (Items) new XmlSerializer(typeof (Items)).Deserialize(s);
         }
      }
    }
