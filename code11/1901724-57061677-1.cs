    using System;
    using System.IO;
    using System.IO.Pipes;
    using System.Text;
    class PipeClient
    {
        static void Main(string[] args)
        {
            using (NamedPipeClientStream pipeClient =
                new NamedPipeClientStream(".", "mySocket", PipeDirection.InOut))
            {
                // Connect to the pipe or wait until the pipe is available.
                Console.WriteLine("Attempting to connect to pipe...");
                pipeClient.Connect();
                try
                {
                    // Read user input and send that to the client process.
                    using (BinaryWriter _bw = new BinaryWriter(pipeClient))
                    using (BinaryReader _br = new BinaryReader(pipeClient))
                    {
                        while (true)
                        {
                            //sw.AutoFlush = true;
                            Console.Write("Enter text: ");
                            var str = Console.ReadLine();
                            var buf = Encoding.ASCII.GetBytes(str);     // Get ASCII byte array
                            _bw.Write((uint)buf.Length);                // Write string length
                            _bw.Write(buf);                              // Write string
                            Console.WriteLine("Wrote: \"{0}\"", str);
                            Console.WriteLine("Let's hear from the server now..");
                            var len = _br.ReadUInt32();
                            var temp = new string(_br.ReadChars((int)len));
                            Console.WriteLine("Received from client: {0}", temp);
                        }
                    }
                }
                // Catch the IOException that is raised if the pipe is broken
                // or disconnected.
                catch (IOException e)
                {
                    Console.WriteLine("ERROR: {0}", e.Message);
                }
            }
            Console.Write("Press Enter to continue...");
        }
    }
