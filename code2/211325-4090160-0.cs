            string n = "wd123.321dw";
            var regNumber = new Regex(@"\-?\d+\.?\d+");
            var match = regNumber.Match(n);
            if ( match.Success )
            {
                double d;
                if ( Double.TryParse(match.Value, out d) )
                {
                    Console.WriteLine("The number is: {0}",d);
                }
            }
