    StreamWriter sw2 = new StreamWriter(saveFile2.FileName);
    Boolean partMatch = false;
    Boolean isAMatch = false;
    List<string> newLines = new List<string>();
    string[] splitDataBaseLines = dataBase2FileRTB.Text.Split('\n');
    foreach (var item in theOtherList)
    {
        foreach (var line in splitDataBaseLines)
        {
            if (line.StartsWith("Component : "))
            {
                partNumberMatch = line.Split(':');
                partNumberMatch[1] = partNumberMatch[1].Remove90,2);
                partNumberMatch[1] = partNumberMatch[1].TrimEnd('"');
                if (partNumberMatch[1].Equals(item.PartNumber))
                {
                    isAMatch = true;
                    sw2.WriteLine();
                }
                partMatch = true;
            }
            if (line.Equals(""))
            {
                partMatch = false;
                isAMatch = false;
            }
            if (partMatch == true && isAMatch == true)
                sw2.WriteLine(line);
        }
    }
    sw2.Close();
