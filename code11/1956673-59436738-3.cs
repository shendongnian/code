    String[] checks = new string[5];
    
    string guess = "SOEEE";
    string secret_word = "SMORE";
    checks = check_word_for_lingo(guess, secret_word);
    
    Console.WriteLine(guess);
    Console.WriteLine(secret_word);
    int i = 0;
    foreach (var item in checks)
    {
        Console.Write(item);
        i++;
    }
