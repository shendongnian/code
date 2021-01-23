    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using ProtoBuf;
    
    [DataContract]
    class Person {
        [DataMember(Name = "CustName", Order = 1)]
        internal string Name;
        public Person(string n) {Name = n;}
        private Person(){} // used by the serializer
    }
    
    internal class Program
    {
        public static void Main()
        {
            WriteObject("my.file", "Mary");
            WriteObject("my.file", "Joe");
            ReadObject("my.file");
        }
    
        public static void WriteObject(string path, string name)
        {
            Person p1 = new Person(name);
            using (FileStream fs = new FileStream(path, FileMode.Append))
            {
                Serializer.SerializeWithLengthPrefix(fs, p1, PrefixStyle.Base128, Serializer.ListItemTag);
            }
        }
    
        public static void ReadObject(string path)
        {
            using(FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                foreach(var person in Serializer.DeserializeItems<Person>(fs, PrefixStyle.Base128, Serializer.ListItemTag))
                {
                    Console.WriteLine("Hello, {0}", person.Name);
                }
            }
        }
    }
