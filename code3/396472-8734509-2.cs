    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    
    namespace BinarySerializationTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                // Serialization of String Object   
      
                String writeData = "Microsoft .NET Framework 4.0";
                FileStream writeStream = new FileStream("C:\\StringObject.data", FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(writeStream, writeData);
                writeStream.Close();
      
                // Deserialization of String Object
    
                FileStream readStream = new FileStream("C:\\StringObject.data", FileMode.Open);
                String readData = (String) formatter.Deserialize(readStream);
                readStream.Close();
                Console.WriteLine(readData);
    
                Console.Read();
            }
        }
    }
