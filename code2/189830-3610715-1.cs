    static string IntListToDelimitedString(List<int> intList, char Delimiter)
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < intList.Count; i++)
        {
            builder.Append(intList[i].ToString());
            if (i != intList.Count - 1)
                builder.Append(Delimiter);
        }
        return builder.ToString();
    }
