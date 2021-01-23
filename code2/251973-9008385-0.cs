    public class SimpleSpamAssassin
    {
        public class RuleResult
        {
            public double Score = 0;
            public string Rule = "";
            public string Description = "";
            public RuleResult() { }
            public RuleResult(string line)
            {
                Score = double.Parse(line.Substring(0, line.IndexOf(" ")).Trim());
                line = line.Substring(line.IndexOf(" ") + 1);
                Rule = line.Substring(0, 23).Trim();
                Description = line.Substring(23).Trim();
            }
        }
        public static List<RuleResult> GetReport(string serverIP, string message) 
        {
            string command = "REPORT";
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} SPAMC/1.2\r\n", command);
            sb.AppendFormat("Content-Length: {0}\r\n\r\n", message.Length);
            sb.AppendFormat(message);
            byte[] messageBuffer = Encoding.ASCII.GetBytes(sb.ToString());
            using (Socket spamAssassinSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                spamAssassinSocket.Connect(serverIP, 783);
                spamAssassinSocket.Send(messageBuffer);
                spamAssassinSocket.Shutdown(SocketShutdown.Send);
                int received;
                string receivedMessage = string.Empty;
                do
                {
                    byte[] receiveBuffer = new byte[1024];
                    received = spamAssassinSocket.Receive(receiveBuffer);
                    receivedMessage += Encoding.ASCII.GetString(receiveBuffer, 0, received);
                }
                while (received > 0);
                spamAssassinSocket.Shutdown(SocketShutdown.Both);
                return ParseResponse(receivedMessage);
            }
        }
        private static List<RuleResult> ParseResponse(string receivedMessage)
        {
            //merge line endings
            receivedMessage = receivedMessage.Replace("\r\n", "\n");
            receivedMessage = receivedMessage.Replace("\r", "\n");
            string[] lines = receivedMessage.Split('\n');
            List<RuleResult> results = new List<RuleResult>();
            bool inReport = false;
            foreach (string line in lines)
            {
                if (inReport)
                {
                    try
                    {
                        results.Add(new RuleResult(line.Trim()));
                    }
                    catch
                    {
                        //past the end of the report
                    }
                }
                if (line.StartsWith("---"))
                    inReport = true;
            }
            return results;
        }
    }
