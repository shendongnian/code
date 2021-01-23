    string input = "123 foo 456";
    int result = 0;
    bool success = int.TryParse(new string(input
                         .SkipWhile(x => !char.IsDigit(x))
                         .TakeWhile(x => char.IsDigit(x))
                         .ToArray()), out result);
