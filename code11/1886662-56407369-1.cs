            // Does not work
            using (StreamReader r = new StreamReader(e.FullPath))
            {
                while (r.EndOfStream == false)
                {
                    m = r.ReadLine();
                }
                r.Close();
            }
            Console.WriteLine("{0}\n", m);
