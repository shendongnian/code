        List<double> ParseLine(string line)
        {
            List<double> ret = new List<double>();
            ret.Add(double.Parse(line.Substring(0, line.IndexOf(' '))));
            line = line.Substring(line.IndexOf(' ') + 1);
            for (; !string.IsNullOrWhiteSpace(line); line = line.Substring(line.IndexOf('E') + 4))
            {
                ret.Add(double.Parse(line.Substring(0, line.IndexOf('E') + 4)));
            }
            return ret;
        }
