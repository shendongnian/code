    private void BtnType1_Click(object sender, RoutedEventArgs e)
    {
        var type1logs = new List<LogData>
        {
            new LogData() { LineNum = 1, Data1 = "Data1A", Data2 = "Data2A" },
            new LogData() { LineNum = 2, Data1 = "Data1B", Data2 = "Data2B" },
            new LogData() { LineNum = 3, Data1 = "Data1C", Data2 = "Data2C" }
        };
        LogDataSet = new LogDataSet() { LogData = type1logs, DisplayColumns = ReadSysFiles("Type1.sys") };
    }
    private void BtnType2_Click(object sender, RoutedEventArgs e)
    {
        var type2logs = new List<LogData>
        {
            new LogData() { LineNum = 1, Data1 = "Data1A", Data3 = "Data3A" },
            new LogData() { LineNum = 2, Data1 = "Data1B", Data3 = "Data3B" },
            new LogData() { LineNum = 3, Data1 = "Data1C", Data3 = "Data3C" }
        };
        LogDataSet = new LogDataSet() { LogData = type2logs, DisplayColumns = ReadSysFiles("Type2.sys") };
    }
