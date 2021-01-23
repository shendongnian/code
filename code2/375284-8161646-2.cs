    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    namespace Cereal
    {
      class Program
      {
        static void Main(string[] args)
        {
          string file = Path.Combine(Environment.CurrentDirectory, "cereal.bin");
			
          List<string> namesToWrite = new List<string>();
          namesToWrite.Add("Frosted Flakes");
          namesToWrite.Add("Fruit Loops");
          namesToWrite.Add("Lucky Charms");
          namesToWrite.Add("Apple Jacks");
          Serialize(file, namesToWrite);
          List<string> namesToRead = Deserialize(file) as List<string>;;
          foreach (string name in namesToRead)
          {
            Console.WriteLine(name);
          }
          Console.ReadLine();
        }
        static void Serialize(string file, object stuff)
        {
          var fmt = new BinaryFormatter();
          using (FileStream fs = File.Open(file, FileMode.Create))
          {
            fmt.Serialize(fs, stuff);
          }
        }
        static object Deserialize(string file)
        {
          var ret = new object();
          var fmt = new BinaryFormatter();
          using (FileStream fs = File.Open(file, FileMode.Open))
          {
            ret = fmt.Deserialize(fs);
          }
          return ret;
        }
      }
    }
