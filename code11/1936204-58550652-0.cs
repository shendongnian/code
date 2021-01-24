    public static class Extensions
    {
        public static string ToFullUnitString(this Length length)
        {
            if (length == null) throw new ArgumentNullException(nameof(length));            
            var units = length.ToString("u").ToLower();
            if (length.Value != 1) units += "s";
            return $"{length:v} {units}";
        } 
    }
