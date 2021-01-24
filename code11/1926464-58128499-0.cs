    for (int i = 0 ; i < inputs.Length ; i++) {
        Console.Write(params[i]);
        string input = Console.ReadLine();
        if (!String.IsNullOrEmpty(input)) {
            int.TryParse(input, out inputs[i]); // "magic" is here
        }
    }
