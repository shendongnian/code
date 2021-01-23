    public static Extentions
    {
        public static string Pluralize(this string str,int n)
        {
            if ( n != 1 )
                return PluralizationService.CreateService(new CultureInfo("en-US"))
                .Pluralize(str);
            return str;
        }
    }
    string.format("you have {0} {1} remaining",liveCount,"life".Pluralize());
