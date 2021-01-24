    string temp = yourText;
    List<int> numbers = new List<int>();
    Regex re = new Regex(@"\d+");
    Match m = re.Match(temp);
    while (m.Success)
    {
        numbers.Add(Convert.ToInt32(m.Value));
        temp = temp.Substring(m.Index + m.Length);
        m = re.Match(temp);
    }
