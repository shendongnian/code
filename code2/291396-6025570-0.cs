    public static class Evaluators
    {
        public static string Wrap( Match m, string original, string format )
        {
            // doesn't match the entire string, otherwise it is a match
            if (m.Length != original.Length)
            {
                // has a preceding letter or digit (i.e., not a real match).
                if (m.Index != 0 && char.IsLetterOrDigit( original[m.Index - 1] ))
                {
                    return m.Value;
                }
                // has a trailing letter or digit (i.e., not a real match).
                if (m.Index + m.Length != original.Length && char.IsLetterOrDigit( original[m.Index + m.Length] ))
                {
                    return m.Value;
                }
            }
            // it is a match, apply the format
            return string.Format( format, m.Value );
        }
    } 
