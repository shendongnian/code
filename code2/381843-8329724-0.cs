        public string RandomString(int size)
        {
            return Guid.NewGuid()
                .ToString()
                .Replace("-","")
                .Substring(0, size);
        }
