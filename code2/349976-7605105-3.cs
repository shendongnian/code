    static void Main(string[] args)
    {
         Bar b1 = new Bar();
         // populate b1 with interesting data
         Bar b2 = new Bar();
         // populate b2 with interesting data
         Foo f = new Foo();
         f.Bars.Add(b1);
         f.Bars.Add(b2);
         f.Something = "My String";
        
         using (MemoryStream ms = new MemoryStream())
         using (System.IO.TextWriter textWriter = new System.IO.StreamWriter(ms))
         {
             System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Foo));
             serializer.Serialize(textWriter, f);
             string text = Encoding.UTF8.GetString(ms.ToArray());
             Console.WriteLine(text);
         }
        Console.ReadKey(false);
    }
