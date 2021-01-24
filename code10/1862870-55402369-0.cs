    public static List<T> ImportCsvIntoObject<T>(string csvFile, string delimiter, Func<string, string, string, T> createObject)
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
                    string parameter1 = fieldData[0];
                    string parameter2 = fieldData[1];
                    string parameter3 = fieldData[2];
                    CSVObject example = createObject(parameter1, parameter2, parameter3)
                    list.Add(example);
                }
            }
            return list;
        }
