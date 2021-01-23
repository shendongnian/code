        public Tuple<double, double> GetXY(string parm)
        {
            Regex regex = new Regex(@"x(?<x>\d+)y(?<y>\d+)");
            Match match = regex.Match(parm);
            if (!match.Success)
                return new Tuple<double, double>(0, 0);
            double x, y;
            double.TryParse(match.Groups["x"].Value, out x);
            double.TryParse(match.Groups["y"].Value, out y);
            return new Tuple<double, double>(x, y);
        }
