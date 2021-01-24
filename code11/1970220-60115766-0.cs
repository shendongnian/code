    class DiffieHellman
    {
        private Aes aes = null;
        private ECDiffieHellmanCng diffieHellman = null;
        private readonly byte[] publicKey;
        public DiffieHellman()
        {
            this.aes = new AesCryptoServiceProvider();
            this.diffieHellman = new ECDiffieHellmanCng
            {
                KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash,
                HashAlgorithm = CngAlgorithm.Sha256
            };
            // This is the public key we will send to the other party
            this.publicKey = this.diffieHellman.PublicKey.ToByteArray();
        }
        public byte[] PublicKey
        {
            get
            {
                return this.publicKey;
            }
        }
        public byte[] IV
        {
            get
            {
                return this.aes.IV;
            }
        }
        public byte[] Encrypt(byte[] publicKey, string secretMessage)
        {
            byte[] encryptedMessage;
            var key = CngKey.Import(publicKey, CngKeyBlobFormat.EccPublicBlob);
            var derivedKey = this.diffieHellman.DeriveKeyMaterial(key); // "Common secret"
            this.aes.Key = derivedKey;
            this.aes.Padding = PaddingMode.Zeros;
            using (var cipherText = new MemoryStream())
            {
                using (var encryptor = this.aes.CreateEncryptor())
                {
                    using (var cryptoStream = new CryptoStream(cipherText, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] ciphertextMessage = Encoding.UTF8.GetBytes(secretMessage);
                        cryptoStream.Write(ciphertextMessage, 0, ciphertextMessage.Length);
                    }
                }
                encryptedMessage = cipherText.ToArray();
            }
            return encryptedMessage;
        }
        public string Decrypt(byte[] publicKey, byte[] encryptedMessage, byte[] iv)
        {
            string decryptedMessage;
            var key = CngKey.Import(publicKey, CngKeyBlobFormat.EccPublicBlob);
            var derivedKey = this.diffieHellman.DeriveKeyMaterial(key);
            this.aes.Key = derivedKey;
            this.aes.IV = iv;
            this.aes.Padding = PaddingMode.Zeros;
            using (var plainText = new MemoryStream())
            {
                using (var decryptor = this.aes.CreateDecryptor())
                {
                    using (var cryptoStream = new CryptoStream(plainText, decryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(encryptedMessage, 0, encryptedMessage.Length);
                    }
                }
                decryptedMessage = Encoding.UTF8.GetString(plainText.ToArray());
            }
            return decryptedMessage;
        }
    }
    class Alice
    {
        static void Main(string[] args)
        {
            while (true)
            {
                DiffieHellman dhke = new DiffieHellman();
                ASCIIEncoding asen = new ASCIIEncoding();
                TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 13000);
                server.Start();
                Socket s = server.AcceptSocket();
                byte[] bobPublicKey = new byte[140];
                byte[] bobIV = new byte[16];
                s.Send(dhke.PublicKey);
                s.Receive(bobPublicKey);
                s.Receive(bobIV);
                byte[] acceptedMessage = new byte[32];
                s.Receive(acceptedMessage);
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Mesazhi qe vjen i enkriptuar " + asen.GetString(acceptedMessage));
                Console.WriteLine();
                string decryptedMessage = dhke.Decrypt(bobPublicKey, acceptedMessage, bobIV);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Friend: ");
                Console.WriteLine(decryptedMessage);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                string mesazhi = Console.ReadLine();
                byte[] encryptedMessage = dhke.Encrypt(bobPublicKey, mesazhi);
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Mesazhi qe dergohet i enkriptuar " + asen.GetString(encryptedMessage));
                Console.WriteLine();
                s.Send(encryptedMessage);
                s.Send(dhke.IV);
                s.Close();
                server.Stop();
            }
        }
    }
    class Bob
    {
        static void Main(string[] args)
        {
            while (true)
            {
                DiffieHellman dhke = new DiffieHellman();
                ASCIIEncoding asen = new ASCIIEncoding();
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect("127.0.0.1", 13000);
                Stream stream = tcpClient.GetStream();
                byte[] alicePublicKey = new byte[140];
                stream.Read(alicePublicKey, 0, alicePublicKey.Length);
                stream.Write(dhke.PublicKey, 0, dhke.PublicKey.Length);
                stream.Write(dhke.IV, 0, dhke.IV.Length);
                Console.ForegroundColor = ConsoleColor.Red;
                String message = Console.ReadLine();  //Shkruaj mesazhin
                byte[] encryptedMessage = dhke.Encrypt(alicePublicKey, message);
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Mesazhi qe dergohet i enkriptuar " + asen.GetString(encryptedMessage));
                Console.WriteLine();
                stream.Write(encryptedMessage, 0, encryptedMessage.Length);
                byte[] acceptedMessage = new byte[32];
                byte[] aliceIV = new byte[16];
                stream.Read(acceptedMessage, 0, acceptedMessage.Length);
                stream.Read(aliceIV, 0, aliceIV.Length);
                Console.WriteLine("Mesazhi qe vjen i enkriptuar " + asen.GetString(acceptedMessage));
                Console.WriteLine();
                string decryptedMessage = dhke.Decrypt(alicePublicKey, acceptedMessage, aliceIV);
                Console.ForegroundColor = ConsoleColor.Green;
                System.Threading.Thread.Sleep(1000);
                Console.Write("Friend: ");
                Console.WriteLine(decryptedMessage);
                Console.WriteLine();
                tcpClient.Close();
            }
        }
    }
