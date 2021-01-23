     static void Main() {
         C c = new C();
         c.Add(123, new A { ID = 456});
         using(var ms = new MemoryStream()) {
             var ser = new BinaryFormatter();
             ser.Serialize(ms, c);
             ms.Position = 0;
             C clone = (C)ser.Deserialize(ms);
             Console.WriteLine(clone.Count); // writes 1
             Console.WriteLine(clone[123].ID); // writes 456
         }
     }
