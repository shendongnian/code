    string input = @"a,b,c,""d,d,d"",e,f,""g,g"",h";
    Console.WriteLine(input);
    string result = Regex.Replace(input,
        @",(?=[^""]*""(?:[^""]*""[^""]*"")*[^""]*$)",
        String.Empty);
    Console.WriteLine(result);
