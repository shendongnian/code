            string[] lines = File.ReadAllLines("Path to your file");
            foreach (string line in lines)
            {
                if (line.Trim() == "")
                {
                    continue;
                }
                string[] numbers = line.Trim().Split(' ');
                foreach (var item in numbers)
                {
                    int number;
                    if (int.TryParse(item, out number))
                    {
                        // you have your number here;
                    }
                }
            }
