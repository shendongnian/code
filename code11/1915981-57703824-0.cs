    string input = "Abc[123]";
    string letters = Regex.Replace(input, "\\[.*\\]", "");
    string numbers = Regex.Replace("Abc[123]", ".*\\[(\\d+)\\]", "$1");
    Console.WriteLine(letters);
    Console.WriteLine(numbers);
