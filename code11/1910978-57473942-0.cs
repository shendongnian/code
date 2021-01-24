    public static class DecimalExtensions
    {
        public static string ToString4Points(this decimal d)
        {
            return d.ToString("F4");
        }
    }
