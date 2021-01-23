    public static class StringHelper
    {
        public static bool AreEquivalent(string source, string target)
        {
            if (source == null) return target == null;
            if (target == null) return false;
            var normForm1 = Normalize(source);
            var normForm2 = Normalize(target);
            return string.Equals(normForm1, normForm2);
        }
    
        private static string Normalize(string value)
        {
            Debug.Assert(value != null);
            // normalize unicode, combining characters, diacritics
            value = value.Normalize(NormalizationForm.FormC);
            // normalize new lines to white space
            value = value.Replace("\r\n", "\n").Replace("\r", "\n");
            // normalize white space
            value = Regex.Replace(value, @"\s", string.Empty);
            // normalize casing
            return value.ToLowerInvariant();
        }
    }
