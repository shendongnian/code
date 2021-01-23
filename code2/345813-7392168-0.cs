            Stream s = File.OpenRead(path);
            StreamReader sr = new StreamReader(s, Encoding.ASCII);
            Console.WriteLine(sr.ReadLine());
            s.Dispose();
            int i = 1;
            try
            {
                while (!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine());
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(i + " lines total");
            Console.ReadLine();
