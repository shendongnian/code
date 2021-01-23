    public struct ComplexStruct
    {
        private Nested1 nested1;
        private Nested2 nested2;
        private Nested3[] nested3;
    
        public bool Read(Reader reader)
        {
           bool ret = true;
           int nested3Length = 0;
    
           ret &&= nested1.Read(reader);
           ret &&= nested2.Read(reader);
           ret &&= reader.ReadInt32(ref nested3Length);
            
           for(int i = 0; (ret && i < nested3Length); i++)
           {
              ret &&= nested3[i].Read(reader);
           }
    
           return ret;
        }
    }
