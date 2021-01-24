    public static decimal ConvertTo6(double d)
        {
            return Math.Round(Convert.ToDecimal(d), 6, MidpointRounding.AwayFromZero);
        }
        public static decimal ConvertTo6(decimal d)
        {
            return Math.Round(d, 6, MidpointRounding.AwayFromZero);
        }
        static void Main(string[] args)
        {
            int input1 = 100000;
            int input2 = 40;
            int input3 = 106833;
            decimal x = 0.000000m;
            decimal y = 0.001000m;
            decimal z;
            decimal r;
            decimal v;
            v = ConvertTo6(Pow(1 / (1 + (Convert.ToDouble(y) / 12d)), input2));
            
            r = ConvertTo6(((y / input2) * input1) / (1 - v));
            
            if (r < input3)
            {
                z = y + Math.Abs((x - y) / 2);
                z = ConvertTo6(z);
            }
            else
            {
                z = y - Math.Abs((x - y) / 2);
                z = ConvertTo6(z);
            }
            x = y;
            y = z;
            while (Math.Abs(r - input3) > 0.001m)
            {
                v = ConvertTo6((Math.Pow(Convert.ToDouble(1 / (1 + (y / 12))), Convert.ToDouble(input2))));
                r = ((y / input2) * input1) / (1 - v);
                r = ConvertTo6(r);
                if (r < input3)
                {
                    z = y + Math.Abs((x - y) / 2);
                    z = ConvertTo6(z);
                }
                else
                {
                    z = y - Math.Abs((x - y) / 2);
                    z = ConvertTo6(z);
                }
                x = y;
                if (y == z) break;
                y = z;
            }
            Console.WriteLine(y * 100);
            Console.Read();
        }
