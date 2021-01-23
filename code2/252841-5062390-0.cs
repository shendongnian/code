    public class bytes : List<byte>
    {
        public bytes()
        {
        }
        public bytes (IList<ArraySegment<byte>> list)
        {
           for ( int i = asb.Offset; i < (asb.Offset + asb .Count); i++ )  
           {
               this.Add(asb.Array[i]);
           }        
        }
    }
