    // - The ^ means that the string must start with whats to follow
    // - The character set [1-9] means that the first character must be 1 - 9.
    // - The character set [0-9] means the next character must be from 0 - 9.
    // - The * means repeat the character class ([0-9]) for 1 to n more characters
    // - The \s means the pattern must then have an immediately trailing whitespace character            
    using (StreamReader sr1 = new StreamReader(@"C:\Temp\Content.txt"))
    using (StreamReader sr2 = new StreamReader(@"C:\Temp\Numbers.txt"))
    using (StreamWriter sw = new StreamWriter(@"C:\Temp\Combined.txt"))
    {
        string curLine;
        while ((curLine = sr1.ReadLine()) != null)
        {
            if (Regex.IsMatch(curLine, "^[1-9][0-9]*\s"))
            {
                sw.WriteLine(curLine + "    " + sr2.ReadLine());
            }
            else
            {
                sw.WriteLine(curLine);
            }
        }
    }
