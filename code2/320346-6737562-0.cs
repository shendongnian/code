            string testString = "Test:34,Test:M,Crocoduck:55";
            string[] data = testString.Split(',');
            for (int i = 0; i < data.Length; i++)
            {
                string s = data[i].Remove(0, data[i].IndexOf(':') + 1);
                int num;
                if (Int32.TryParse(s, out num))
                {
                    Console.WriteLine(num);
                }
            }
