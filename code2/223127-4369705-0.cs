    public string GetRandomString(int length)
    {
        var newBuffer = new byte[length];
        if (length <= 0)
            return null;
            
        // This was used for a password generator... change this how every needed
        var charSet = ("ABCDEFGHJKLMNPQRSTUVWXYZ" +
                       "abcdefghijkmnprstuvxyz" +
                       "23456789").ToCharArray();
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(newBuffer);
            var newChars = newBuffer.Select(b => charSet[b % charSet.Length]).ToArray();
            return new string(newChars);
        }
    }
