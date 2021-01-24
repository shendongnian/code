    public static int SquareDigits(int n)
            {
    
                char[] digits = n.ToString();
                String result = "";
                foreach (char ch in digits)
                {
                    double squared = Math.Pow(Int32.Parse(ch.ToString()),2);
                    result += squared.ToString();
                }
                return Int32.Parse(result);
            }
