        static readonly Regex VectorRegex = new Regex(@"a:(?<A>[0-9]+\.[0-9]+);b:(?<B>[0-9]+\.[0-9]+);c:(?<C>[0-9]+\.[0-9]+)", RegexOptions.Compiled);
        static Tuple<double, double, double> ParseVector(string input)
        {
            var m = VectorRegex.Match(input);
            if (m.Success)
            {
                double a, b, c;
                a = double.Parse(m.Groups["A"].Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                b = double.Parse(m.Groups["B"].Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                c = double.Parse(m.Groups["C"].Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                return new Tuple<double, double, double>(a, b, c);
            }
            else
                throw new FormatException("Invalid input format");
        }
