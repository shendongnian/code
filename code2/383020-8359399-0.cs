    public class Spinner
    {
        private static Random rnd = new Random();
        public static string Spin(string str)
        {
            string regex = @"\{(.*?)\}";
            return Regex.Replace(str, regex, new MatchEvaluator(WordScrambler));
        }
        public static string WordScrambler(Match match)
        {
            string[] items = match.Value.Substring(1, match.Value.Length - 2).Split('|');
            return items[rnd.Next(items.Length)];
        }
    }
