    public static string collatz(string y)
    {
        if (y == null)
            return null;
        double x = double.Parse(y);
        y = x.ToString();
        double large = x;
        while (x > 1) {
            if (x % 2 == 0) {
                x = x / 2;      // x reassigned
                if (x > large)
                    large = x;
                if (x != 1)
                    y = y + " " + x.ToString();
                if (x == 1) {
                    y = y + " " + x.ToString();
                    y = y + " largest number was " + large;
    
                }
            }
            // Infinite loop goes because of that
            if (x % 2 != 0) {  // double check on reassigned variable, use “else” instead
                if (x == 1) {
                    y = y + " " + x.ToString();
                    y = y + " largest number was " + large;
    
                }
                x = (3 * x) + 1;
                if (x > large)
                    large = x;
                y = y + " " + x.ToString();
            }
        }
        return y;
    }
