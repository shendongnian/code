     public void Close()
        {
            Array.Clear(Values, 0, Values.Length);
            Stream.Close();
            Stream.Dispose();
        }
        public int Depth
        {
            get { return 0; }
        }
        public DataTable GetSchemaTable()
        {
            // avoid to implement several methods if your scenario do not demand it
            throw new NotImplementedException();
        }
        public bool IsClosed
        {
            get { return Eof; }
        }
        public bool NextResult()
        {
            return false;
        }
        public bool Read()
        {
            CurrentRecord = Stream.ReadLine();            
            Eof = CurrentRecord == null;
            if (!Eof)
            {
                Fill(Values);
                CurrentIndex++;
            }
            return !Eof;
        }
        private void Fill(object[] values)
        { 
           //To simplify the implementation, lets assume here that the table have just 3         
           //columns: the primary key, and 2 string columns. And the file is fixed column formatted 
          //and have 2 columns: the first with width 12 and the second with width 40. Said that, we can do as follows
   
            values[0] = null;
            values[1] = CurrentRecord.Substring(0, 12).Trim();
            values[2] = CurrentRecord.Substring(12, 40).Trim();
           // by default, the first position of the array hold the value that will be  
           // inserted at the first column of the table, and so on
           // lets assume here that the primary key is auto-generated
            // if the file is xml we could parse the nodes instead of Substring operations
        } 
        public int RecordsAffected
        {
            get { return -1; }
        } 
