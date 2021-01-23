    string[] stringSeparator = new string[] {"\",\""};
    while (!sr.EndOfStream) 
    {
        //trim removes first and last quote since they are not removed by the split
        string line = sr.ReadLine().Trim('"');
        string[] values = line.Split(stringSeparator, StringSplitOptions.None);
        for (int index = 0; index < values.Length; index++)
            MessageBox.Show(values[index]);
    }
