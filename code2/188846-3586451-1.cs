    string optional = "with a clause I don't want" 
    string rx = "^(.*?)" + Regex.Escape(optional) + ".*$";
    // displays "I have a sentence"
    string foo = "I have a sentence with a clause I don't want.";
    Console.WriteLine(Regex.Replace(foo, rx, "$1"));
    // displays "I have a sentence and I like it."
    string bar = "I have a sentence and I like it.";
    Console.WriteLine(Regex.Replace(bar, rx, "$1"))
