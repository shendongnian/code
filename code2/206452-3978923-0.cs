       public DateTime? ReadNullableDateTimefromReader(string field, IDataRecord data)
        {
            var a = data[field];
            if (a != DBNull.Value)
            {
                return Convert.ToDateTime(a);
            }
            return null;
        }
        public DateTime ReadDateTimefromReader(string field, IDataRecord data)
        {
            DateTime value;
            var valueAsString = data[field].ToString();
            try
            {
                value = DateTime.Parse(valueAsString);
            }
            catch (Exception)
            {
                throw new Exception("Cannot read Datetime from reader");
            }
            return value;
        }
