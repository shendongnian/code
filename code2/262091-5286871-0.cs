            string filename = "";
            do
            {
                Console.WriteLine("Enter the file name with extension:");
                filename = Environment.GetEnvironmentVariable("HOMEDRIVE") + Environment.GetEnvironmentVariable("HOMEPATH") + "\\Desktop\\" + Console.ReadLine();
                if (!System.IO.File.Exists(filename))
                    Console.WriteLine("File doesn't exist!");
                else
                    break;
            } while (true);
            System.IO.StreamReader readfile = new System.IO.StreamReader(filename);
            List<string> Names = new List<string>();
            List<int[]> Numbers = new List<int[]>();
            string val = "";
            while ((val = readfile.ReadLine()) != null)
            {
                if (val == string.Empty)
                    continue;
                List<string> parts = val.Split(' ').ToList<string>();
                Names.Add(parts[0]);
                parts.RemoveAt(0);
                Numbers.Add(parts.ConvertAll<int>(delegate(string i) { return int.Parse(i); }).ToArray());
            }
            readfile.Close();
            //Print out info
            foreach (string name in Names)
            {
                Console.Write(name + ", ");
            }
            Console.WriteLine();
            foreach (int[] Numberset in Numbers)
            {
                Console.Write("{");
                foreach (int number in Numberset)
                    Console.Write(number + ", ");
                Console.Write("} ");
            }
            Console.ReadLine();
