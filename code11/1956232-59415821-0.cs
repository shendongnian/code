C#
    string Extract(string s, int position)
    {
        var split = s.Split(',');
        return split.Length > position ? split[position] : " ";
    }
    lotID = Extract(inputGetData.ReadLine(), 2);
