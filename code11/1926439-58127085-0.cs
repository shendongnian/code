string[] temp = line.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
for (int i = 0; i < cityNames.Length; i++)
{
    temp[i] += cityNames[i];
}
string result = string.Join(",\n", temp);
return result.Remove(result.Length - 3, 2);
