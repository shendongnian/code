	/// <summary>
    /// http://stackoverflow.com/questions/5343006/is-there-a-c-sharp-type-for-representing-an-integer-range
    /// </summary>
    public class Range
    {
        readonly static char[] Separators = {','};
        public static List<int> Explode(int from, int to)
        {
            return Enumerable.Range(from, (to-from)+1).ToList();
        }
        
        public static List<int> Interpret(string input)
        {
            var result = new List<int>();
            var values = input.Split(Separators);
            string rangePattern = @"(?<range>(?<from>\d+)-(?<to>\d+))";
            var regex = new Regex(rangePattern);
            foreach (string value in values)
            {
                var match = regex.Match(value);
                if (match.Success)
                {
                    var from = Parse(match.Groups["from"].Value);
                    var to = Parse(match.Groups["to"].Value);
                    result.AddRange(Explode(from, to));
                }
                else
                {
                    result.Add(Parse(value));
                }
            }
            return result;
        }
        /// <summary>
        /// Split this out to allow custom throw etc
        /// </summary>
        private static int Parse(string value)
        {
            int output;
            var ok = int.TryParse(value, out output);
            if (!ok) throw new FormatException($"Failed to parse '{value}' as an integer");
            return output;
        }
    }
