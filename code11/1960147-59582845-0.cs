    static void Main(string[] args)
    {
        var lines = File.ReadAllLines("text.txt");
        var newLines = new string[lines.Count()];
        for (var i = 0; i < lines.Count(); i++)
        {
            if (i == 0)
            {
                newLines[i] = lines[i].ToUpper();
            }
            else
            {
                foreach (var word in lines[i].Split(' '))
                {
                    newLines[i] += string.Format("{0} ", word.Length >= 3 ? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word) : word);
                }
            }
        }
        File.WriteAllLines("newText.txt", newLines);
    }
