    public static class DateHelper
    {
        public static string ToLocalizedLongTimeString(this DateTime target)
        {
            return ToLocalizedLongTimeString(target, CultureInfo.CurrentCulture);
        }
        public static string ToLocalizedLongTimeString(this DateTime target, 
            CultureInfo ci)
        {
            // I'm only looking for fr-CA because the OP mentioned this 
            // is specific to fr-CA situations...
            if (ci.Name == "fr-CA")
            {
                if (target.Minute == 0)
                {
                    return target.ToString("H' h'");
                }
                else
                {
                    return target.ToString("H' h 'mm");
                }
            }
            else
            {
                return target.ToLongTimeString();
            }
        }
    }
