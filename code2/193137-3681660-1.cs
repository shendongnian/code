    string input = "aBcdefGhI123jKLMo$";
    string result = Regex.Replace(input, "[a-zA-Z]",
                                m => Char.IsUpper(m.Value[0]) ?
                                     Char.ToLower(m.Value[0]).ToString() :
                                     Char.ToUpper(m.Value[0]).ToString());
    Console.WriteLine("Original: " + input);
    Console.WriteLine("Modified: " + result);
