    using (StreamReader sr1 = new StreamReader(@"C:\Temp\Content.txt"))
    using (StreamReader sr2 = new StreamReader(@"C:\Temp\Numbers.txt"))
    using (StreamWriter sw = new StreamWriter(@"C:\Temp\Combined.txt"))
    {
        string curLine;
        while ((curLine = sr1.ReadLine()) != null)
        {
            if (Regex.IsMatch(curLine, "^[1-9][0-9]*"))
            {
                sw.WriteLine(curLine + "    " + sr2.ReadLine());
            }
            else
            {
                sw.WriteLine(curLine);
            }
        }
    }
