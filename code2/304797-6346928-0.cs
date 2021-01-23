    public class StackOverflow_6346646
    {
        static void SerializeGuid()
        {
            Console.WriteLine("Serializing Guid[]");
            var guids = new Guid[20000];
            Random rndGen = new Random();
            for (int i = 0; i < guids.Length; i++)
            {
                guids[i] = Guid.NewGuid();
            }
            MemoryStream ms = new MemoryStream();
            Stopwatch watch = new Stopwatch();
            DataContractSerializer dcs = new DataContractSerializer(guids.GetType());
            XmlDictionaryWriter binaryWriter = XmlDictionaryWriter.CreateBinaryWriter(ms);
            watch.Start();
            dcs.WriteObject(binaryWriter, guids);
            binaryWriter.Flush();
            watch.Stop();
            Console.WriteLine("Serialized in {0}ms, total size = {1} bytes", watch.ElapsedMilliseconds, ms.Position);
        }
        static void SerializeInt()
        {
            Console.WriteLine("Serializing int[]");
            var guids = new int[80000]; // new Guid[20000];
            Random rndGen = new Random();
            for (int i = 0; i < guids.Length; i++)
            {
                guids[i] = rndGen.Next(); // Guid.NewGuid();
            }
            MemoryStream ms = new MemoryStream();
            Stopwatch watch = new Stopwatch();
            DataContractSerializer dcs = new DataContractSerializer(guids.GetType());
            XmlDictionaryWriter binaryWriter = XmlDictionaryWriter.CreateBinaryWriter(ms);
            watch.Start();
            dcs.WriteObject(binaryWriter, guids);
            binaryWriter.Flush();
            watch.Stop();
            Console.WriteLine("Serialized in {0}ms, total size = {1} bytes", watch.ElapsedMilliseconds, ms.Position);
        }
        static void SerializeGuidAsByteArray(bool useLinq)
        {
            Console.WriteLine("Serializing Guid[] as byte[], {0}", useLinq ? "using LINQ" : "not using LINQ");
            var guids = new Guid[20000];
            Random rndGen = new Random();
            for (int i = 0; i < guids.Length; i++)
            {
                guids[i] = Guid.NewGuid();
            }
            MemoryStream ms = new MemoryStream();
            Stopwatch watch = new Stopwatch();
            DataContractSerializer dcs = new DataContractSerializer(typeof(byte[]));
            XmlDictionaryWriter binaryWriter = XmlDictionaryWriter.CreateBinaryWriter(ms);
            watch.Start();
            byte[] bytes;
            if (useLinq)
            {
                bytes = guids.SelectMany(x => x.ToByteArray()).ToArray();
            }
            else
            {
                bytes = new byte[guids.Length * 16];
                for (int i = 0; i < guids.Length; i++)
                {
                    byte[] guidBytes = guids[i].ToByteArray();
                    Buffer.BlockCopy(guidBytes, 0, bytes, 16 * i, 16);
                }
            }
            dcs.WriteObject(binaryWriter, bytes);
            binaryWriter.Flush();
            watch.Stop();
            Console.WriteLine("Serialized in {0}ms, total size = {1} bytes", watch.ElapsedMilliseconds, ms.Position);
        }
        public static void Test()
        {
            SerializeGuid();
            SerializeInt();
            SerializeGuidAsByteArray(true);
            SerializeGuidAsByteArray(false);
        }
    }
