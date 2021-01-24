string[] ReadLines = File.ReadAllLines(start);
string line = string.Empty;
if (ReadLines.Count() > 7)
{
    line = $"{ReadLines[4]}{ReadLines[5]}{ReadLines[6]}".ToLower();
}
else
{
    line = string.Join("", ReadLines);
}
int len = line.Length;
for (int i = 0; i < len; i++)
{
    if (line[i] == 'a' || line[i] == 'e' || line[i] == 'i' || line[i] == 'o' || line[i] == 'u')
    {
        vowel++;
    }
}
richTextBox3.AppendText(vowel.ToString() + " ");
