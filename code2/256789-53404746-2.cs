    class CompareTwoCSVFile
    {
        public  bool ReportErrorOnCompareCSV(string filePathOne, string filePathTwo)
        {
            var csv = new StringBuilder();
            string[] fileContentsOne = File.ReadAllLines(filePathOne);
            string[] fileContentsTwo = File.ReadAllLines(filePathTwo);
    
            if (!fileContentsOne.Length.Equals(fileContentsTwo.Length))
                return false;
    
            string[] columnshead1 = fileContentsOne[0].Split(new char[] { ';' });
            List<string> heading1 = new List<string>();
            Dictionary<string, string>[] dict1 = new Dictionary<string, string>[fileContentsOne.Length];
            Dictionary<string, string>[] dict2 = new Dictionary<string, string>[fileContentsTwo.Length];
            string[] headingsplit = columnshead1[0].Split(',');
            for (int i=0;i< headingsplit.Length;i++)
            {
                heading1.Add(headingsplit[i]);
            }
    
            var newLine = "";
            newLine = string.Format("{0},{1},{2},{3}", "File1_ColumnName", "File1_ColumnValue", "File2_ColumnName", "File2_ColumnValue");
            csv.AppendLine(newLine);
    
            for (int i = 0; i < fileContentsOne.Length-1; ++i)
            {
                    string[] columnsOne = fileContentsOne[i+1].Split(new char[] { ';' });
                    string[] columnsTwo = fileContentsTwo[i+1].Split(new char[] { ';' });
                    string[] cellOne = columnsOne[0].Split(',');
                    string[] cellTwo = columnsTwo[0].Split(',');
                    dict1[i] = new Dictionary<string, string>();
                    dict2[i] = new Dictionary<string, string>();
                    for(int j=0;j< headingsplit.Length;j++)
                    {
                        dict1[i].Add(heading1[j],cellOne[j]);
                    }
                    for (int j = 0; j < headingsplit.Length; j++)
                    {
                        dict2[i].Add(heading1[j], cellTwo[j]);
                    }
                    foreach (KeyValuePair<string, string> entry in dict1[i])
                    {
                       if (dict2[i][entry.Key].Equals(entry.Value)!=true)
                       {
                           Console.WriteLine("Mismatch Values on row "+i+":\n File1 "+entry.Key + "-" + entry.Value+"\n File2 "+entry.Key+"-"+ dict2[i][entry.Key]);
                        newLine = string.Format("{0},{1},{2},{3}", entry.Key, entry.Value, entry.Key, dict2[i][entry.Key]);
                        csv.AppendLine(newLine);
                       }
                   }
                }
                File.WriteAllText("D:\\Errorlist.csv", csv.ToString());
                return true;
        }
}
