        static bool ParseCoordinates(string parm, out double x, out double y)
        {
            string[] res = parm.Replace("x","")
                               .Replace("y",",")
                               .Split(",".ToCharArray());
            
            bool parseX = double.TryParse(res[0], out x);
            bool parseY = double.TryParse(res[1], out y);
            return parseX && parseY;
        }
