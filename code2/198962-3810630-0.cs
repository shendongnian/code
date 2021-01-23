    public string GeneratePassword(Random rng)
    {
        char[] chars = new char[7];
        for (int i = 0; i < 7; i++)
        {
            chars[i] = pwdCharArray[rng.Next(i)];
        }
        return new string(chars);
    }
