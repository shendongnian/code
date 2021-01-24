            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\test.txt");
            while ((line = file.ReadLine()) != null)
            {
                var data = line.Split(':');
                string ipAdd = data[0];
                int port = int.Parse(data[1]);
                
                //Your conditions here...
                Console.WriteLine(ipAdd);
                Console.WriteLine(port);
            }
