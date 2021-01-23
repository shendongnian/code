            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                IPAddress IP = IPAddress.Parse("192.168.1.2");
                IPEndPoint IPE = new IPEndPoint(IP, 4321);
                s.Connect(IPE);
                byte[] buffer = new byte[55296];
                int rec = s.Receive(buffer, SocketFlags.None);
                using (MemoryStream ms = new MemoryStream(buffer, 0, rec))
                {
                    Image im = new Bitmap(ms);
                    pictureBox1.Image = im;
                }
            }
