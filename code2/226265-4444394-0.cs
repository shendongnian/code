            string message = "this is your message";
            byte packetType = 1;
            byte checksum = 0;
            
            // calculate a simple checksum
            foreach (char c in message)
            {
                checksum ^= (byte)c;
            }
            // type, message, checksum into buffer
            // (uses list instead of playing with arrays for expeditious example code)
            List<byte> buffer = new List<byte>();
            buffer.Add(packetType);
            buffer.AddRange(ASCIIEncoding.UTF8.GetBytes(message));
            buffer.Add(checksum);
            // write out to the socket
            CommStream.Write(buffer.ToArray(), 0, buffer.Count);
