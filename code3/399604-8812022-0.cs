        static Tuple<Double, Double> ParseCoordinates(string parm)
        {
            string[] res = parm.Replace("x","")
                               .Replace("y",",")
                               .Split(",".ToCharArray());
            double x, y;
            double.TryParse(res[0], out x);
            double.TryParse(res[1], out y);
            return new Tuple<double, double>(x, y);
        }
