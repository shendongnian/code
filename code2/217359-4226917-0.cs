       public class Program
        {
            [Serializable]
            public class Test
            {
                public int Id { get; set; }
                public Test()
                {
    
                }
            }
    
            public static void Main()
            {   
                //create a list of 10 Test objects with Id's 0-10
                List<Test> firstList = Enumerable.Range(0,10).Select( x => new Test { Id = x } ).ToList();
                using (var stream = new System.IO.MemoryStream())
    
                {
                     var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                     binaryFormatter.Serialize(stream, firstList); //serialize to stream
                     stream.Position = 0;
                     //deserialize from stream.
                     List<Test> secondList = binaryFormatter.Deserialize(stream) as List<Test>; 
                }
    
    
                Console.ReadKey();
            }
        }
