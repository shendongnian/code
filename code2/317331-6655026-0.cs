        private void FixCurrentDateFormat()
        {
            var cc = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            var df = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat;
            df.FullDateTimePattern = PatchPattern(df.FullDateTimePattern);
            df.LongDatePattern = PatchPattern(df.LongDatePattern);
            df.ShortDatePattern = PatchPattern(df.ShortDatePattern);
            //change any other patterns that you could use
            //replace the current culture with the patched culture
            System.Threading.Thread.CurrentThread.CurrentCulture = cc;
        }
        private string PatchPattern(string pattern)
        {
            //modify the pattern to your liking here
            //in this example, I'm replacing "d" with "dd" and "M" with "MM"
            string newPattern = Regex.Replace(pattern, "\bd\b", "dd");
            newPattern = Regex.Replace(pattern, "\bM\b", "dd");
            return newPattern;
        }
