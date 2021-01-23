        private static void Main(string[] args)
        {
            using (MemoryMappedFile mmf = MemoryMappedFile.CreateNew("memfile", 128))
            {
                using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                {
                    BinaryWriter writer = new BinaryWriter(stream);
                    writer.Write(512);
                }
                Console.WriteLine("Starting the child process");
                // Command line args are separated by a space
                Process p = Process.Start("ChildProcess.exe", "memfile");
                Console.WriteLine("Waiting child to die");
                p.WaitForExit();
                Console.WriteLine("Child died");
                using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                {
                    BinaryReader reader = new BinaryReader(stream);
                    Console.WriteLine("Result:" + reader.ReadInt32());
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
