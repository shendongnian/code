    class MyDTO
    {
        public stirng Field1{get;set;}
        public stirng Field2{get;set;}
        public stirng Field3{get;set;}
    }
    
    public IEnumerable<MyDTO> ReaderToStream(IDataReader reader)
    {
        while(reader.Read())
        {
            var line=reader.GetString(0);
            var fields=String.Split(",",line);
            yield return new MyDTO{Field1=fields[0];Field2=fields[1];Field3=fields[2]};
        }
    }
