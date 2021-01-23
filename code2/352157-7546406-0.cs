            int lineCounter = 0;
            StreamReader strReader = new StreamReader(path);
            while (!strReader.EndOfStream)
            {
                string fileLine = strReader.ReadLine();
                if (Regex.IsMatch(fileLine,pattern))
                {
                    Console.WriteLine(pattern + "found in line " +lineCounter.ToString());
                }
                lineCounter++;
            }
