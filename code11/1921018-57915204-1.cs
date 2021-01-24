`C#
for (int i = 0; i < count; i++)
{
    string[] temp2;
    temp2 = ReadText[i].Split(' ');
    for (int a = 0; a < temp2.Length; a++)
        if (float.TryParse(temp2[a], out Value[ValueCount]))
            ValueCount++;
}
`
You can also try `StringSplitOptions`
`C#
for (int i = 0; i < count; i++)
{
    string[] temp2;
    temp2 = ReadText[i].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
    for (int a = 0; a < temp2.Length; a++)
        Value[a] = float.Parse(temp2[a]);
}
`
