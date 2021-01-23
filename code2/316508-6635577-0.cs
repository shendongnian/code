        using (StreamReader sr1 = new StreamReader(@"C:\Temp\PartNumbers.txt"))
        using (StreamReader sr2 = new StreamReader(@"C:\Temp\Bom.txt"))
        using (StreamWriter sw = new StreamWriter(@"C:\Temp\Combined.txt"))
        {
            while (!sr2.EndOfStream)
            {
                string curLine = sr2.ReadLine();
                // Get the numeric portion (if any)
                string strNum = "";
                for(int i=0; i<curLine.Length; i++)
                {
                    // Check for positive non-zero integers 
                    Regex patt = new Regex("0*[1-9][0-9]*");
                    string test = curLine[i].ToString();
                    if (patt.IsMatch(test))
                    {
                        strNum += curLine[i];
                    }
                    else
                    {
                        break;
                    }
                }
                // If we parsed the numeric then write the new line w/numeric appended else just write the original line
                if (!string.IsNullOrEmpty(strNum))
                {
                    sw.WriteLine(curLine + "    " + sr1.ReadLine());
                }
                else
                {
                    sw.WriteLine(curLine);
                }
            }
        } 
