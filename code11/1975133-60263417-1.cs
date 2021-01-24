    static void Main(string[] args)
    {
        int price = 100;
        Regex regex = new Regex(@"(?<=\{).*?(?=\})");
        string userInput = "Hi. I want to buy your computer. I can't offer {price} USD, but I can offer {price-(price/100)*10} USD";
        string text = userInput;
        foreach (var item in regex.Matches(text))
        {
            string expression = item.ToString().Replace("price", price.ToString());
            var interpreter = new Interpreter();
            var result = interpreter.Eval(expression);
            text = regex.Replace(text, result.ToString(),1);
            text = ReplaceFirst(text, "{", string.Empty);
            text = ReplaceFirst(text, "}", string.Empty);
        }
        Console.WriteLine("Result: " + text);
    }
    public static string ReplaceFirst(string text, string search, string replace)
    {
        int pos = text.IndexOf(search);
        if (pos < 0)
        {
            return text;
        }
        return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
    }
