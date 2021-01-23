    public class bytes : List<byte>
    {
        public bytes()
        {
        }
        public bytes (IList<ArraySegment<byte>> list)
        {
           for ( int i = 0; i < list.Count; i++ )  
           {
               this.Add(asb.Array[i]);
           }        
        }
    }
