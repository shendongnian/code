    bool Validate(string input)
    {
        // list of all predicates to check
        IEnumerable<Predicate<string>> rules = new Predicate<string>[]
        {
            ContainsInvalidCharacters,
            ContainsRepetitiveDigits,
            StartsWithZero,
            IsSequence
        };
        // check if any rule matches
        foreach (Predicate<string> check in rules)
            if (check(input))
                return false;
        
        // if no match, it means input is valid
        return true;
    }
