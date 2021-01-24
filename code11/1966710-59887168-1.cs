    class DataFactory
    {
        public static BaseData BuildDataClass(byte[] serializedData)
        {
            Dictionary<string,string> data = ParseData(serializedData);
            switch (data["DataType"])
            {
                case "TypeA":
                    return new DataTypeA(data);
                
                default:
                    return null;
            }
        }
    
        private static Dictionary<string,string> ParseData(byte[] serializedData)
        {
            var data = new Dictionary<string, string>();
    
            // bla bla
    
            return data;
        }
    }
