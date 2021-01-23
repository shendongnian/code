    public class DataReaderWithEOF
    {
         public bool EOF { public get; private set; }
         private IDataReader reader;
    
         public DataReaderWithEOF(IDataReader reader)
         {
              this.reader = reader;
         }
    
         public bool Read()
         {
               bool result = reader.Read();
               this.EOF = !result;
               return result;
         }
    }
