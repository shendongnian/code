    var sb = new StringBuilder(input.Length);
    int nextIndexToAdd = 0;
    for (int i = 1; i < input.Length;i++ )
        if (char.IsUpper(input[i])
            && !char.IsWhiteSpace(input[i - 1])
            && (!char.IsUpper(input[i - 1]) || (i < input.Length - 1 && !char.IsUpper(input[i + 1]))))
            {
                sb.Append(input.Substring(nextIndexToAdd, i - nextIndexToAdd));
                sb.Append(" ");
                nextIndexToAdd = i;
            }
    sb.Append(input.Substring(nextIndexToAdd));
    string result = sb.ToString();
