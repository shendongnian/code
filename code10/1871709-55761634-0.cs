            private static void Main(string[] args)
        {
            try
            {
                var connection = new HubConnection("http://localhost:7132/");
                IHubProxy hub = connection.CreateHubProxy("ChatHub");
                hub.On<string, string>("broadcastMessage", (name, message) => { Console.Write(name + ": "); Console.WriteLine(message); });
                connection.Start().Wait();
                hub.Invoke("Notify", "Console app", connection.ConnectionId);
                string msg = null;
                while ((msg = Console.ReadLine()) != null)
                {
                    hub.Invoke("Send", "Console app", msg).Wait();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.Message);
            }
        }
