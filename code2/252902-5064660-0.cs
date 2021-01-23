    using (StreamReader CsvReader = new StreamReader(input_file))
                    {
                        string inputLine = "";
    
                        while ((inputLine = CsvReader.ReadLine()) != null)
                        {
                            values.Add(inputLine.Trim().Replace(",", "").Replace(" ", ""));
                        }
                        CsvReader.Close();
                        return values;
                    }
