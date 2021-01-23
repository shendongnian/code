        public static object test(string inputString)
        {
            object obj = null;
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(inputString)))
            {
                try
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ASErrorResponse));
                    obj = ser.ReadObject(ms) as ASErrorResponse;
                }
                catch (SerializationException)
                {
                    
                }
            }
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(inputString)))
            {
                try
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ASResponse));
                    obj = ser.ReadObject(ms) as ASResponse;
                }
                catch (SerializationException)
                {
                }
            }
            return obj;
        }
