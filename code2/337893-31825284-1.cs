    int Port = 500;
            TcpListener listener = new TcpListener(IPAddress.Any, Port);
            listener.Start();
            Socket socket = listener.AcceptSocket();
            int bufferSize = 1024;
            byte[] buffer = null;
            byte[] header = null;
            string headerStr = "";
            string filename = "";
            int filesize = 0;
            header = new byte[bufferSize];
            socket.Receive(header);
            headerStr = Encoding.ASCII.GetString(header);
            string[] splitted = headerStr.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            Dictionary<string, string> headers = new Dictionary<string, string>();
            foreach (string s in splitted)
            {
                if (s.Contains(":"))
                {
                    headers.Add(s.Substring(0,s.IndexOf(":")), s.Substring(s.IndexOf(":") + 1));
                }
                
            }
            //Get filesize from header
            filesize = Convert.ToInt32(headers["Content-length"]);
            //Get filename from header
            filename = headers["Filename"];
            int bufferCount = Convert.ToInt32(Math.Ceiling((double)filesize / (double)bufferSize));
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            while(filesize > 0)
            {
                buffer = new byte[bufferSize];
                int size = socket.Receive(buffer,SocketFlags.Partial);
                fs.Write(buffer,0,size);
                filesize -= size;
            }
            fs.Close();
