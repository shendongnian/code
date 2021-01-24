    public static class Extensions
    {
        public static string Formatted(this double d)
        {
            if (d >= 1e+15)
            {
                return d.ToString(CultureInfo.GetCultureInfo("es-ES"));
            }
            else
            {
                return d.ToString("#,##0.###############", CultureInfo.GetCultureInfo("es-ES"));
            }
        }
    }
