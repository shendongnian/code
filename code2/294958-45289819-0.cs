    public class SmsHelper
    {
        public void SendSms(string toNumber, string content)
        {
            bool connected;
            TcpClient smsServer = OpenConnection("xyz.xy.x.xyz", xyzd, out connected);//require ip and port
            if (connected)
            {
                string sms = content; 
                SendSmsToClient(smsServer, Properties.Settings.Default.FromNumber, toNumber, sms);
            }
        }
        protected static TcpClient OpenConnection(string ip, int port, out bool connected)
        {
            string response = string.Empty;
            string message = string.Empty;
            TcpClient tcpClient = new TcpClient();
            try
            {
                ASCIIEncoding ascEn = new ASCIIEncoding();
                tcpClient.Connect(ip, port);
                Stream stream = tcpClient.GetStream();
                byte[] bb = new byte[100];
                stream.Read(bb, 0, 100);
                string connect = ascEn.GetString(bb);
                if (!String.IsNullOrEmpty(connect))
                {
                    //authenticating to smsServer
                    string str = "action: login\r\nusername: xxxxx\r\nsecret: integration\r\n\r\n";
                    byte[] ba = ascEn.GetBytes(str);
                    stream.Write(ba, 0, ba.Length);
                    stream.Flush();
                    byte[] resp = new byte[100];
                    stream.Read(resp, 0, 100);
                    response = ascEn.GetString(resp);
                    stream.Read(resp, 0, 100);
                    message = ascEn.GetString(resp);
                    if (response.Contains("Success") && message.Contains("Authentication accepted"))
                    {
                        Console.WriteLine("Authenticated");
                        stream.Flush();
                        connected = true;
                        return tcpClient;
                    }
                    else
                    {
                        Console.WriteLine("Credentials error Cant Authenticate");
                        tcpClient.Close();
                        connected = false;
                        return tcpClient;
                    }
                }
                connected = false;
                return tcpClient;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connected = false;
            return tcpClient;
        }
        protected static void CloseConnection(TcpClient client)
        {
            client.Close();
            Console.WriteLine("Connection Closed process terminated...");
        }
        protected static void SendSmsToClient(TcpClient client, string fromNumber, string toNumber, string smsBody)
        {
            string response = string.Empty;
            string message = string.Empty;
            string eventMsg = string.Empty;
            ASCIIEncoding asen = new ASCIIEncoding();
            Stream stm = client.GetStream();
            string smsSend = string.Format("action: smscommand\r\ncommand: gsm send sms {0} {1} \r\n\r\n", fromNumber, toNumber);
            byte[] smsCmd = asen.GetBytes(smsSend);
            stm.Write(smsCmd, 0, smsCmd.Length);
            stm.Flush();
            byte[] smsResp = new byte[1000];
            stm.Read(smsResp, 0, 1000);
            response = asen.GetString(smsResp);
            if (!String.IsNullOrEmpty(response))
            {
                stm.Read(smsResp, 0, 1000);
                message = asen.GetString(smsResp);
                if (!String.IsNullOrEmpty(message))
                {
                    stm.Read(smsResp, 0, 1000);
                    eventMsg = asen.GetString(smsResp);
                    if (!String.IsNullOrEmpty(eventMsg))
                    {
                        String[] list = eventMsg.Split('\n');
                        foreach (string value in list)
                        {
                            if (value.StartsWith("--END"))
                            {
                                stm.Flush();
                            }
                        }
                    }
                }
            }
        }
    }
