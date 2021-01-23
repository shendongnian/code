     public int FieldCount
        {
            get { return 3;//assuming the table has 3 columns }
        }
        public IDataReader GetData(int i)
        {
            if (i == 0)
                return this;
            return null;
        }
        public string GetDataTypeName(int i)
        {
            return "String";
        }
        public string GetName(int i)
        {
            return Values[i].ToString();
        }
        public string GetString(int i)
        {
            return Values[i].ToString();
        }
        public object GetValue(int i)
        {
            return Values[i];
        }
        public int GetValues(object[] values)
        {
            Fill(values);
            Array.Copy(values, Values, this.FieldCount);
            return this.FieldCount;
        }
        public object this[int i]
        {
            get { return Values[i]; }
        }  
