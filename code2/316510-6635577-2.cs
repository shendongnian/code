        using (StreamReader sr1 = new StreamReader(@"C:\Temp\Content.txt"))
        using (StreamReader sr2 = new StreamReader(@"C:\Temp\Numbers.txt"))
        using (StreamWriter sw = new StreamWriter(@"C:\Temp\Combined.txt"))
        {
            while (!sr1.EndOfStream)
            {
                string curLine = sr1.ReadLine();
                Regex patt = new Regex("^[1-9][0-9]*");
                // If we parsed the numeric then write the new line w/numeric appended else just write the original line
                if (patt.IsMatch(curLine))
                {
                    sw.WriteLine(curLine + "    " + sr2.ReadLine());
                }
                else
                {
                    sw.WriteLine(curLine);
                }
            }
        }
