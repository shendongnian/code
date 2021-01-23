    public static string ReplaceOnce(this string input, string oldValue, string newValue)
    {
        int index = input.IndexOf(oldValue);
        if (index > -1)
        {
            return input.Remove(index, oldValue.Length).Insert(index, newValue);
        }
        return input;
    }
//
    Debug.Assert("bar bar bar".ReplaceOnce("bar", "foo").Equals("foo bar bar"));
