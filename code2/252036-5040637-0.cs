    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using ProtoBuf;
    static class Program {
      
        static void Main() {
            var rand = new Random(123456);
            var timeOrigin = new DateTime(2010,1,1);
            Serializer.PrepareSerializer<MyFunRecord>();
            Console.WriteLine("Writing .proto ...");
            const int LOOP = 500000;
            using (var file = File.Create("raw.data"))
            {
                var watch = Stopwatch.StartNew();
                double total = 0;
                for (int i = 0; i < LOOP; i++)
                {
                    var obj = new MyFunRecord();
                    obj.Id = i;
                    obj.Count = rand.Next(500);
                    obj.Value = rand.NextDouble() * 4000;
                    obj.When = timeOrigin.AddDays(rand.Next(1000));
                    obj.Name = RandomString(rand);
                    Serializer.SerializeWithLengthPrefix(file, obj, PrefixStyle.Base128, Serializer.ListItemTag);
                    total += obj.Value;
                }
                watch.Stop();
                Console.WriteLine(file.Length / (1024 * 1024)+ "MB");
                Console.WriteLine(total + " (check)");
                Console.WriteLine(watch.ElapsedMilliseconds + "ms");
            }
            rand = new Random(123456);
            Console.WriteLine();
            Console.WriteLine("Writing tsv ...");
            using (var file = File.Create("raw.tsv"))
            {
                using (var writer = new StreamWriter(file))
                {
                    var watch = Stopwatch.StartNew();
                    double total = 0;
                    for (int i = 0; i < LOOP; i++)
                    {
                        var obj = new MyFunRecord();
                        obj.Id = i;
                        obj.Count = rand.Next(500);
                        obj.Value = rand.NextDouble() * 4000;
                        obj.When = timeOrigin.AddDays(rand.Next(1000));
                        obj.Name = RandomString(rand);
    
                        Write(writer, obj);
    
                        total += obj.Value;
                    }
                    watch.Stop();
                    Console.WriteLine(file.Length / (1024 * 1024) + "MB");
                    Console.WriteLine(total + " (check)");
                    Console.WriteLine(watch.ElapsedMilliseconds + "ms");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Reading .proto ...");
            using(var file = File.OpenRead("raw.data"))
            {
                var watch = Stopwatch.StartNew();
                double total = 0;
                foreach (var obj in Serializer.DeserializeItems<MyFunRecord>(file, PrefixStyle.Base128, Serializer.ListItemTag))
                {
                    total += obj.Value;
                    
                }
                watch.Stop();
                Console.WriteLine(total + " (check again)");
                Console.WriteLine(watch.ElapsedMilliseconds + "ms");
            }
            Console.WriteLine();
            Console.WriteLine("Reading tsv ...");
            using (var file = File.OpenRead("raw.tsv"))
            using (var reader = new StreamReader(file))
            {
                var watch = Stopwatch.StartNew();
                double total = 0;
                foreach (var obj in Read(reader))
                {
                    total += obj.Value;
    
                }
                watch.Stop();
                Console.WriteLine(total + " (check again)");
                Console.WriteLine(watch.ElapsedMilliseconds + "ms");
            }
           
    
    
        }
    
        private static void Write(TextWriter writer, MyFunRecord obj)
        {
            writer.Write(obj.Id);
            writer.Write('\t');
            writer.Write(obj.Name);
            writer.Write('\t');
            writer.Write(obj.When);
            writer.Write('\t');
            writer.Write(obj.Value);
            writer.Write('\t');
            writer.Write(obj.Count);
            writer.WriteLine();
        }
        private static IEnumerable<MyFunRecord> Read(TextReader reader)
        {
            string line;
            char[] delim = new[] { '\t' };
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(delim);
                var obj = new MyFunRecord();
                obj.Id = int.Parse(parts[0]);
                obj.Name = parts[1];
                obj.When = DateTime.Parse(parts[2]);
                obj.Value = double.Parse(parts[3]);
                obj.Count = int.Parse(parts[4]);
                yield return obj;
            }
    
        }
        static string RandomString(Random rand)
        {
            int len = rand.Next(1, 20);
            var sb = new StringBuilder(len);
            for (int i = 0; i < len; i++)
            {
                sb.Append('a' + rand.Next(26));
            }
            return sb.ToString();
        }
    
    }
    [ProtoContract]
    class MyFunRecord
    {
        [ProtoMember(1)]public int Id { get; set; }
        [ProtoMember(2)]public string Name { get; set; }
        [ProtoMember(3)] public DateTime When { get; set; }
        [ProtoMember(4)] public double Value { get; set; }
        [ProtoMember(5)] public int Count { get; set; }
    }
