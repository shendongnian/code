            TcpClient mail = new TcpClient();
            SslStream sslStream;
            int bytes = -1;
            
            mail.Connect("pop.gmail.com", 995);
            sslStream = new SslStream(mail.GetStream());
            sslStream.AuthenticateAsClient("pop.gmail.com");
            byte[] buffer = new byte[2048];
            // Read the stream to make sure we are connected
            bytes = sslStream.Read(buffer, 0, buffer.Length);
            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytes));
            //Send the users login details
            sslStream.Write(Encoding.ASCII.GetBytes("USER USER_EMAIL\r\n"));
            bytes = sslStream.Read(buffer, 0, buffer.Length);
            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytes));
            //Send the password                        
            sslStream.Write(Encoding.ASCII.GetBytes("PASS USER_PASSWORD\r\n"));
            bytes = sslStream.Read(buffer, 0, buffer.Length);
            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytes));
            // Get the first email 
            sslStream.Write(Encoding.ASCII.GetBytes("RETR 1\r\n"));
            bytes = sslStream.Read(buffer, 0, buffer.Length);
            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytes));
