        private static void Main(string[] args)
        {
            Console.WriteLine("Child process started");
            string mmfName = args[0];
            using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(mmfName))
            {
                int readValue;
                using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                {
                    BinaryReader reader = new BinaryReader(stream);
                    Console.WriteLine("child reading: " + (readValue = reader.ReadInt32()));
                }
                using (MemoryMappedViewStream input = mmf.CreateViewStream())
                {
                    BinaryWriter writer = new BinaryWriter(input);
                    writer.Write(readValue * 2);
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
