    private double DoWork(string data)
        {
            double final = 0;
            foreach (string s in data.Split(' '))
            {
                if (s.Contains('/'))
                {
                    final += double.Parse(s.Split('/')[0]) / double.Parse(s.Split('/')[1]);
                }
                else
                {
                    double tryparse = 0;
                    double.TryParse(s, out tryparse);
                    final += tryparse;
                }
            }
            return final;
        }
