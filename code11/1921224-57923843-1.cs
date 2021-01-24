        void ParseLine(string line, out double a, out double b, out double c, out double d, out double e, out double f)
        {
            a = double.Parse(line.Substring(0, line.IndexOf(' ')));
            line = line.Substring(line.IndexOf(' ') + 1);
            b = double.Parse(line.Substring(0, line.IndexOf('E') + 4));
            line = line.Substring(line.IndexOf('E') + 4).Trim();
            c = double.Parse(line.Substring(0, line.IndexOf('E') + 4));
            line = line.Substring(line.IndexOf('E') + 4).Trim();
            d = double.Parse(line.Substring(0, line.IndexOf('E') + 4));
            line = line.Substring(line.IndexOf('E') + 4).Trim();
            e = double.Parse(line.Substring(0, line.IndexOf('E') + 4));
            line = line.Substring(line.IndexOf('E') + 4).Trim();
            f = double.Parse(line.Substring(0, line.IndexOf('E') + 4));
        }
