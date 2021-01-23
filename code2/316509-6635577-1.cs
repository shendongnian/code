        using (StreamReader sr1 = new StreamReader(@"C:\Temp\PartNumbers.txt"))
        using (StreamReader sr2 = new StreamReader(@"C:\Temp\Bom.txt"))
        using (StreamWriter sw = new StreamWriter(@"C:\Temp\Combined.txt"))
        {
            while (!sr2.EndOfStream)
            {
                string curLine = sr2.ReadLine();
                Regex patt = new Regex("^0*[1-9][0-9]*");
                // If we parsed the numeric then write the new line w/numeric appended else just write the original line
                if (patt.IsMatch(curLine))
                {
                    sw.WriteLine(curLine + "    " + sr1.ReadLine());
                }
                else
                {
                    sw.WriteLine(curLine);
                }
            }
        }
