    public override string Encrypt(string input)
    { 
        Func<char, char> encryption = (c) => (char)chars[(c * k1 + k0) % 26]; 
        return string.Concat(input.Select(c => encryption(c)));
    }
