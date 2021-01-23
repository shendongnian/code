                pmOffice pmO = new pmOffice();
                pmO.GetpmOffice(3, false);
                TcpClient mail = new TcpClient();
                SslStream sslStream;
                int bytes = -1;
                mail.Connect("outlook.office365.com", 993);
                sslStream = new SslStream(mail.GetStream());
                sslStream.AuthenticateAsClient("outlook.office365.com");
                byte[] buffer = new byte[2048];
                // Read the stream to make sure we are connected
                bytes = sslStream.Read(buffer, 0, buffer.Length);
                Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytes));
                //Send the users login details (insert your username & password in the following line
                sslStream.Write(Encoding.ASCII.GetBytes("$ LOGIN " + pmO.mailUsername + " " + pmO.mailPassword + "\r\n"));
                bytes = sslStream.Read(buffer, 0, buffer.Length);
                string strOut = Encoding.ASCII.GetString(buffer, 0, bytes);
                
                // Get the status of the inbox (# of messages)
                sslStream.Write(Encoding.ASCII.GetBytes("$ STATUS INBOX (messages)\r\n"));
                bytes = sslStream.Read(buffer, 0, buffer.Length);
                strOut = Encoding.ASCII.GetString(buffer, 0, bytes);
