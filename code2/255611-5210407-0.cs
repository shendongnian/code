        private static string dec2frac(double dbl)
        {
            char neg = ' ';
            double dblDecimal = dbl;
            if (dblDecimal == (int) dblDecimal) return dblDecimal.ToString(); //return no if it's not a decimal
            if (dblDecimal < 0)
            {
                dblDecimal = Math.Abs(dblDecimal);
                neg = '-';
            }
            var whole = (int) Math.Truncate(dblDecimal);
            string decpart = dblDecimal.ToString().Replace(Math.Truncate(dblDecimal) + ".", "");
            double rN = Convert.ToDouble(decpart);
            double rD = Math.Pow(10, decpart.Length);
            string rd = recur(decpart);
            int rel = Convert.ToInt32(rd);
            if (rel != 0)
            {
                rN = rel;
                rD = (int) Math.Pow(10, rd.Length) - 1;
            }
            //just a few prime factors for testing purposes
            var primes = new[] {46, 43, 37, 31, 29, 23, 19, 17, 13, 11, 7, 5, 3, 2};
            foreach (int i in primes) reduceNo(i, ref rD, ref rN);
            rN = rN + (whole*rD);
            return string.Format("{0}{1}/{2}", neg, rN, rD);
        }
