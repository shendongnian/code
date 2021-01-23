    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    
    public class Program
    {
        public static void Main(String[] args)
        {
            Random rng = new Random();
            Console.WriteLine("Values before saving...");
            ShowValues(rng);
            
            BinaryFormatter formatter = new BinaryFormatter(); 
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, rng);
    
            Console.WriteLine("Values after saving...");
            ShowValues(rng);
            
            stream.Position = 0; // Rewind ready for reading
            Random restored = (Random) formatter.Deserialize(stream);
            
            Console.WriteLine("Values after restoring...");
            ShowValues(restored);       
        }
        
        static void ShowValues(Random rng)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(rng.Next(100));
            }
        }
    }
