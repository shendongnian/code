        public static string toFraction(string exp) {
            double x = Convert.ToDouble(exp);
            int sign = (Math.Abs(x) == x) ? 1 : -1;
            x = Math.Abs(x);
            int n = (int)x; // integer part
            x -= n; // fractional part
            int mult, nm, dm;
            int decCount = 0;
            Match m = Regex.Match(Convert.ToString(x), @"([0-9]+?)\1+.?$");
            // repeating fraction
            if (m.Success) {
                m = Regex.Match(m.Value, @"([0-9]+?)(?=\1)");
                mult = (int)Math.Pow(10, m.Length);
                // We have our basic fraction
                nm = (int)Math.Round(((x * mult) - x));
                dm = mult - 1;
            }
            // get the number of decimal places
            else {
                double t = x;
                while (t != 0) {
                    decCount++;
                    t *= 10;
                    t -= (int)t;
                }
                mult = (int)Math.Pow(10, decCount);
                // We have our basic fraction
                nm = (int)((x * mult));
                dm = mult;
            }
            // can't be simplified
            if (nm < 0 || dm < 0) return exp;
            //Simplify
            Stack factors = new Stack();
            for (int i = 2; i < nm + 1; i++) {
                if (nm % i == 0) factors.Push(i);  // i is a factor of the numerator
            }
            // check against the denominator, stopping at the highest match
            while(factors.Count != 0) {
                // we have a common factor
                if (dm % (int)factors.Peek() == 0) {
                    int f = (int)factors.Pop();
                    nm /= f;
                    dm /= f;
                    break;
                }
                else factors.Pop();
            }
            nm += (n * dm);
            nm *= sign;
            if (dm == 1) return Convert.ToString(nm);
            else return Convert.ToString(nm) + "/" + Convert.ToString(dm);
        }
