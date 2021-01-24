string[,] ParseFromFile (string fileName)
{
    // Assume that your table have 10 cols and 100 rows
    string[,] result = new string[10,100];
    string str = File.ReadAllText (fileName);
    // Split each line to arrays
    string[] yourStringArray = str.Split(new[]{'\r', '\n'},StringSplitOptions.RemoveEmptyEntries);
    for (int i == 0; i < yourStringArray; i++)
    {
        string[] row = yourStringArray[i].Split(new[]{" "},StringSplitOptions.RemoveEmptyEntries);
        result[i] = row;
    }
    return result;
}
Use List:
List<List<string>> ParseFromFile (string fileName)
{
    // Your list
    List<List<string>> result = new List<List<string>>();
    string str = File.ReadAllText (fileName);
    // Split each line to arrays
    string[] yourStringArray = str.Split(new[]{'\r', '\n'},StringSplitOptions.RemoveEmptyEntries);
    for (int i == 0; i < yourStringArray; i++)
    {
        List<string> row = yourStringArray[i].Split(new[]{" "},StringSplitOptions.RemoveEmptyEntries).ToList();
        result.Add(row);
    }
    return result;
}
