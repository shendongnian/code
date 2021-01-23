    using System;
    using System.Text;
    class Program
    {
        static Random rng = new Random();
        static string GetChoiceTemplatingResult(string t)
        {
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < t.Length; ++i)
                if (t[i] == '{')
                {
                    int j;
                    for (j = i + 1; j < t.Length; ++j)
                        if (t[j] == '}')
                        {
                            if (j - i < 1) continue;
                            var choices = t.Substring(i + 1, j - i - 1).Split('|');
                            res.Append(choices[rng.Next(choices.Length)]);
                            i = j;
                            break;
                        }
                    if (j == t.Length)
                        throw new InvalidOperationException("No matching } found.");
                }
                else
                    res.Append(t[i]);
            return res.ToString();
        }
        static void Main(string[] args)
        {
            Console.WriteLine(GetChoiceTemplatingResult(
                "{Hello|Hi|Hi-Hi} my {mate|m8|friend|friends}, {i|we} want to {tell|say} you {hello|hi|hi-hi}."));
        }
    }
