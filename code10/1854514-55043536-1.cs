    public List<CsvData> ReadCsv(string file)
    {
        List<CsvData> collection = new List<CsvData>();
        using (var streamReader = new StreamReader(file))
        {
            while (!streamReader.EndOfStream)
            {
                string[] columns = streamReader.ReadLine().Split(';');
                CsvData data = new CsvData();
                data.column1 = columns[0];
                data.column2 = columns[1];
                data.column3 = columns[2];
                data.column4 = columns[3];
                data.column5 = columns[4];
                data.column6 = columns[5];
                data.column7 = columns[6];
                data.column8 = columns[7];
                data.column9 = columns[8];
                collection.Add(data);
            }
        }
        return collection;
    }
