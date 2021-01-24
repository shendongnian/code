    bool Validate(string s)
    {
        string[] valid = {"0", "1", "a", "b"};
        var splitArray = s.Split(':');
        if (splitArray.Length < 1 || splitArray.Length > 4)
              return false;
        return splitArray.All(a => valid.Contains(a));
    }
