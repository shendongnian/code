    public static List<T> ImportCsvIntoObject<T>(string csvFile, string delimiter, Func<List<string>, T> createObject)
        {
            List<T> list = new List<T>();
            using (TextFieldParser csvReader = new TextFieldParser(csvFile))
            {
                csvReader.SetDelimiters(new String[] { delimiter });
                csvReader.HasFieldsEnclosedInQuotes = true;
                //Parse the file and creates a list of CSVObject
                //example with a csv file with 3 columns
                while (!csvReader.EndOfData)
                {
                    string[] fieldData = csvReader.ReadFields();
                    CSVObject example = createObject(fieldData.ToList())
                    list.Add(example);
                }
            }
            return list;
        }
