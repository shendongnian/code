lanaguage=cs
[Serializable()]
public class t_Task
{
   private string nom;
   private string description;
   List<t_Task> subTask;
}
**Here is a sample based upon the Microsoft article I linked**
language=cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace ConsoleOne
{
    [Serializable()]
    public class t_Task
    {
        private string nom = "test"; // Added for test data.
        private string description = "desc"; // Added for test data
        List<t_Task> subTask = new List<t_Task>();
        public void AddTask()
        {
            this.subTask.Add(new t_Task());
        }
        public override string ToString()
            => $"{nom}-{description}-{subTask?.Count}";
    }
    class Program
    {
        static void Main(string[] args)
        {
            var task = new t_Task()
            {
            };
            task.AddTask();
            task.AddTask();
            // Opens a file and serializes the object into it in binary format.
            Stream stream = File.Open("data.xml", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, task);
            stream.Close();
            //Empties obj.
            task = null;
            //Opens file "data.xml" and deserializes the object from it.
            stream = File.Open("data.xml", FileMode.Open);
            formatter = new BinaryFormatter();
            //formatter = new BinaryFormatter();
            task = (t_Task)formatter.Deserialize(stream);
            stream.Close();
            Console.WriteLine($"{task}");
            Console.ReadLine();
        }
    }
}
Note: There are many other avenues for serialization in .NET that are a bit more modern.  It may be worth reading about these as well.
* [Serialization in .NET](https://docs.microsoft.com/en-us/dotnet/standard/serialization/)
* [Json.NET](https://www.newtonsoft.com/json)
