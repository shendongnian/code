    public class SerializableWork
    {
        // This is very often between 100-120k bytes. This is actually a String - not just for the purposes of this example
        public String WorkContext { get; set; }
        // This is quite large as well but usually less than 85k bytes. This is actually a String - not just for the purposes of this example
        public String ContextResult { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initial memory: {0}", GC.GetTotalMemory(true));
            var sw = new SerializableWork { WorkContext = new string(' ', 1000000), ContextResult = new string(' ', 1000000) };
            Console.WriteLine("Memory with objects: {0}", GC.GetTotalMemory(true));
            using (var mq = new MessageQueue(@".\Private$\Test1"))
            {
                mq.Send(sw);
            }
            sw = null;
            Console.WriteLine("Memory after collect: {0}", GC.GetTotalMemory(true));
            using (var mq = new MessageQueue(@".\Private$\Test1"))
            {
                StringBuilder sb1, sb2;
                using (var msg = mq.Receive())
                {
                    Console.WriteLine("Memory after receive: {0}", GC.GetTotalMemory(true));
                    using (var reader = XmlTextReader.Create(msg.BodyStream))
                    {
                        reader.ReadToDescendant("WorkContext");
                        reader.Read();
                        sb1 = ReadContentAsStringBuilder(reader);
                        reader.ReadToFollowing("ContextResult");
                        reader.Read();
                        sb2 = ReadContentAsStringBuilder(reader);
                        Console.WriteLine("Memory after creating sb: {0}", GC.GetTotalMemory(true));
                    }
                }
                Console.WriteLine("Memory after freeing mq: {0}", GC.GetTotalMemory(true));
                GC.KeepAlive(sb1);
                GC.KeepAlive(sb2);
            }
            Console.WriteLine("Memory after final collect: {0}", GC.GetTotalMemory(true));
        }
        private static StringBuilder ReadContentAsStringBuilder(XmlReader reader)
        {
            var sb = new StringBuilder();
            char[] buffer = new char[4096];
            int read;
            while ((read = reader.ReadValueChunk(buffer, 0, buffer.Length)) != 0)
            {
                sb.Append(buffer, 0, read);
            }
            return sb;
        }
    }
