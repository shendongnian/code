    class Program
    {
        const string IMAGE_DIR = @"C:\Users\joehoper\Desktop\imgservtest\client\";
        const int CONNECT_PORT = 10001;
        const int BUFFER_SIZE = 10240;
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to start sending...");
            Console.ReadLine();
            foreach (string filename in Directory.GetFiles(IMAGE_DIR))
                SendImage(filename);
        }
        static void SendImage(string filename)
        {
            var client = new TcpClient("localhost", CONNECT_PORT);
            using (var cs = client.GetStream())
            {
                // Send filename
                byte[] fNameBytes = Encoding.Unicode.GetBytes(Path.GetFileName(filename));
                cs.WriteByte((byte)fNameBytes.Length);
                cs.Write(fNameBytes, 0, fNameBytes.Length);
                using (var fs = File.OpenRead(filename))
                {
                    // Send image data
                    byte[] buffer = new byte[BUFFER_SIZE];
                    while (true)
                    {
                        int r = fs.Read(buffer, 0, BUFFER_SIZE);
                        if (r == 0)
                            break;
                        cs.Write(buffer, 0, r);
                    }
                }
            }
            client.Close();
        }
    }
