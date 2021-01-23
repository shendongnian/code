    public static class PolyConverter
    {
        static Regex latlngMatch = new Regex(@"(-?\d{1,2}\.\dE-\d+|-?\d{1,2}\.?\d*)\s(-?\d{1,2}\.\dE-\d+|-?\d{1,2}\.?\d*)\s?0?\s?0?,?", RegexOptions.Compiled);
        static Regex reformat = new Regex(@"\[,", RegexOptions.Compiled);
        public static string ConvertPolysToJson(string polysIn)
        {
            var formatted = reformat.Replace(
                            latlngMatch.Replace(
                            polysIn.Remove(0, polysIn.IndexOf("(")), ",{lng:$1,lat:$2}")
                            .Replace("(", "[")
                            .Replace(")", "]"), "[");
            if (polysIn.Contains("MULTIPOLYGON"))
            {
                formatted = formatted.Replace("[[", "[")
                                     .Replace("]]", "]")
                                     .Replace("[[[", "[[")
                                     .Replace("]]]", "]]");
            }
            return formatted;
        }
    }
