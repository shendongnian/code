    class Program
    {
        static void Main(string[] args)
        {
            //Random rand = new Random();
            int numberOfTasks = 256; //number of tasks
            int numberOfServers; //number of servers
            numberOfServers = 64;//Convert.ToInt32(Console.ReadLine())
            Console.WriteLine("Number of servers(m): " + numberOfServers);
            //int d = 1; //random servers to be chosen
            Console.WriteLine("Number of tasks(n): " + numberOfTasks);
            //Console.WriteLine("Number of randomly selected server(d): " + d);
            //Main server setup
            Server[] servers = new Server[numberOfServers];
            for (int i = 0; i < numberOfServers; i++)
            {
                servers[i] = new Server(i);
            }
            for(int i = 0; i < numberOfTasks; i++){
                var minimumTasksValue = servers.Min(x => x.Tasks);
                var listOfServersToSpread = servers.Where(x => x.Tasks == minimumTasksValue).ToList();
                Random rand = new Random();
                var randomServer = rand.Next(0, listOfServersToSpread.Count() - 1);
                listOfServersToSpread[randomServer].Tasks++;
            }
            //Server min max
            Server maxServer = new Server();
            maxServer = servers[0];
            for (int i = 0; i < numberOfServers; i++)
            {
                if (maxServer.Tasks < servers[i].Tasks)
                {
                    maxServer = servers[i];
                }
            }
            Console.WriteLine("\nIndex of servers with most tasks: " + "[" + maxServer.SNo + "]");
            Console.WriteLine("Highest number of tasks: " + maxServer.Tasks + "\n");
            Server minServer = new Server();
            minServer = servers[0];
            for (int i = 0; i < numberOfServers; i++)
            {
                if (minServer.Tasks > servers[i].Tasks)
                {
                    minServer = servers[i];
                }
            }
            Console.WriteLine("\nIndex of servers with least tasks: " + "[" + minServer.SNo + "]");
            Console.WriteLine("Lowest number of tasks: " + minServer.Tasks + "\n");
            //details
            details(servers);
            
            Console.ReadLine();
        }
        static void details(Server[] server)
        {
            var numberOfTasksAvailable = server.Select(x => x.Tasks).Distinct().OrderBy(x => x);
            foreach(var numberOfTasks in numberOfTasksAvailable)
            {
                Console.WriteLine("There are " + server.Count(x => x.Tasks == numberOfTasks) + " servers with " + numberOfTasks + " tasks.");
            }            
        }
    }
