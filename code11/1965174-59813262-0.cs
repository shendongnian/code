    static string firstWord(string s1, int num)
    {
        return s1.Split(' ').FirstOrDefault(x => x.Contains(s1.ElementAt(num)));
    }
You can use this in your main class like this,
    string input = "Alena has 2 hands";
    Console.WriteLine(firstWord(input, 2));
**Output**
Alena
