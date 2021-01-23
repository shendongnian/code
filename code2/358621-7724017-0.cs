        public string DoPing<T>(T IP)
        {
            if (typeof(T) == typeof(string))
            {
                return DoPingString((String)Convert.ChangeType(IP, typeof(String)));
            }
            if (typeof(T) == typeof(IPAddress))
            {
                return DoPingIP((IPAddress)Convert.ChangeType(IP, typeof(IPAddress)));
            }
            throw new Exception("Programmer Error");
        }
