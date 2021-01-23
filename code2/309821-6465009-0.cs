     private IEnumerable<dynamic> GetRecords(
                        string filePath,
                        IEnumerable<string> columnNames, 
                        string[] delimiter){
                if (!File.Exists(filePath))
                    yield break;
                var columns = columnNames.ToArray();
                dynamic New = new ClayFactory();
                using (var streamReader = new StreamReader(filePath)){
                    var columnLength = columns.Length;
                    string line;
                    while ((line = streamReader.ReadLine()) != null){
                        var record = New.Record();
                        var fields = line.Split(delimiter, StringSplitOptions.None);
                        if(fields.Length != columnLength)
                            throw new InvalidOperationException(
                                     "fields count does not match column count");
                        for(int i = 0;i<columnLength;i++){
                            record[columns[i]] = fields[i];
                        }
                        yield return record;
                    }
                }
            }
