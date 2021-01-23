    class Class1
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            System.Net.Sockets.TcpClient tcp = new System.Net.Sockets.TcpClient("localhost",12345);
            Send s = new Send();
            s.sendFile("c:\\boot.ini",tcp.GetStream());
        }
    }
    public class Send
    {
        TripleDESCryptoServiceProvider tripleDES;
        public Send()
        {
            tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = Encoding.Unicode.GetBytes("foobar12foob".ToCharArray());
            tripleDES.IV = Encoding.Unicode.GetBytes("foob".ToCharArray());
        }
        public void sendFile(String fileName, Stream networkStream)
        {
            FileStream fin = new FileStream(fileName,FileMode.Open, FileAccess.Read);
            //Create variables to help with read and write.
            byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
            long rdlen = 0; //This is the total number of bytes written.
            long totlen = fin.Length; //This is the total length of the input file.
            int len; //This is the number of bytes to be written at a time.
            CryptoStream encStream = new CryptoStream(networkStream, tripleDES.CreateEncryptor(), CryptoStreamMode.Write);
            Console.WriteLine("Encrypting...");
            //Read from the input file, then encrypt and write to the output file.
            while(rdlen < totlen)
            {
                len = fin.Read(bin, 0, 100);
                encStream.Write(bin, 0, len);
                rdlen = rdlen + len;
                //Console.WriteLine("{0} bytes processed", rdlen);
            }
            encStream.Close();
        }
    }
    class Class2
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //
            // TODO: Add code to start application here
            //
            Receive r = new Receive();
            System.IO.FileStream fs = System.IO.File.OpenWrite("c:\\test.txt");
            System.Net.Sockets.TcpListener tcp = new TcpListener(12345);
            tcp.Start();
            r.receiveFile(fs,tcp.AcceptTcpClient().GetStream());
            System.Console.ReadLine();
        }
    }
    public class Receive
    {
        TripleDESCryptoServiceProvider tripleDES;
        public Receive()
        {
            tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = Encoding.Unicode.GetBytes("foobar12foob".ToCharArray());
            tripleDES.IV = Encoding.Unicode.GetBytes("foob".ToCharArray());
        }
        public void receiveFile(FileStream fs, NetworkStream ns)
        {
            while(!ns.DataAvailable){}
            byte[] bin = new byte[100];
            long rdlen = 0;
            int len = 100;
            CryptoStream decStream = new CryptoStream(fs,tripleDES.CreateDecryptor(),    CryptoStreamMode.Write);
            Console.WriteLine("Decrypting...");
       
            while(len > 0)
            {
                len = ns.Read(bin, 0, len);
                rdlen = rdlen + len;
                decStream.Write(bin,0,len);
                Console.WriteLine("{0} bytes read, {1} total bytes", len, rdlen);
            }
            decStream.FlushFinalBlock();
            decStream.Close();
            ns.Close();
            fs.Close();
        }
    }
