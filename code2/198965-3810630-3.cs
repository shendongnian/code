    public string GeneratePassword(Random rng)
    {
        char[] chars = new char[7];
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = pwdCharArray[rng.Next(pwdCharArray.Length)];
        }
        return new string(chars);
    }
