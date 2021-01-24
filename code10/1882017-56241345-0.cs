    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    using MailKit;
    using MailKit.Net.Smtp;
    
    namespace ConsoleApp {
        public class Program
        {
            static void Main (string[] args)
            {
                using (var client = new SmtpClient (new ProtocolLogger ("smtp.log"))) {
                    using (var cts = new CancellationTokenSource (60000)) {
                        try {
                            client.Connect ("your-host.com", 25, false, cts.Token);
                            client.Disconnect (true);
                        } catch (Exception ex) {
                            Console.WriteLine ("Error connecting: {0}", ex.Message);
                            Console.WriteLine (ex.StackTrace);
                        }
                    }
                }
            }
        }
    }
