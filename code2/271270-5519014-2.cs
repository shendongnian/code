    string separator = ",";
    for (int i = 0; i < column.Length; i++)
    {
        query.Append(column[i]);
        query.Append(separator);
    }
    query.Length -= separator.Length;
