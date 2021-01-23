    List<SomeDataClass> filesToMove = new List<SomeDataClass>();
    
    public T deserializeJSON<T>(string json)
            {
                var instance = typeof(T);
                var lst = new List<SomeDataClass>();
                
                using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
                {
                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(lst.GetType());
                    return (T)deserializer.ReadObject(ms);
                }
            }
    someJsonArrayString = "[{\"ID\":7},{\"ID\":16}]";
    filesToMove = deserializeJSON<List<SomeDataClass>>(someJsonArrayString);
    Console.WriteLine(filesToMove[1].ID); // returns 16
