    public static class ExcelRangeExt {
        static Regex excelRangeRE = new Regex(@"[A-Z]+[0-9]+:[A-Z]+[0-9]+", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        static Regex betweenPosRE = new Regex(@"(?<=\p{L})(?=\d)", RegexOptions.Compiled);
    
        public static bool IsExcelRange(this string r) => excelRangeRE.IsMatch(r);
        public static bool IsExcelRowOrCol(this string r) {
            var valid = excelRangeRE.IsMatch(r);
            if (valid) {
                var splitr = r.Split(':').Select(s => betweenPosRE.Split(s)).ToList();
                valid = splitr[0][0] == splitr[1][0] // is column
                        || splitr[0][1] == splitr[1][1]; // is row
            }
            return valid;
        }
    }
