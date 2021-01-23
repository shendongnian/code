            TcpClient mail = new TcpClient();
            SslStream sslStream;
            mail.Connect("pop.gmail.com", 995);
            sslStream = new SslStream(mail.GetStream());
            sslStream.AuthenticateAsClient("pop.gmail.com");
            byte[] buffer = new byte[2048];
            StringBuilder messageData = new StringBuilder();
            int bytes = -1;
            do
            {
                bytes = sslStream.Read(buffer, 0, buffer.Length);
                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(buffer, 0, bytes)];
                decoder.GetChars(buffer, 0, bytes, chars, 0);
                messageData.Append(chars);
                if (messageData.ToString().IndexOf("<EOF>") != -1)
                {
                    break;
                }
            } while (bytes != 0);
            Console.Write(messageData.ToString());
            Console.ReadKey();
