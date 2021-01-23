    static string ReplaceSmile(Match m) {
        string x = m.ToString();
        if (x.Equals(":)")) {
            return "happy";
        } else if (x.Equals(":(")) {
            return "sad";
        }
        return x;
    }
    static void Main() {
        string text = "Today is a sunny day :). But tomorrow it is going to rain :(";
        Regex rx = new Regex(@":[()]");
        string result = rx.Replace(text, new MatchEvaluator(ReplaceSmile));
        System.Console.WriteLine("result=[" + result + "]");
    }
