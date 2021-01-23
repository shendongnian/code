    class MyParseBase <T>
    {
      public MyBase (Func<string,T> parseMethod)
      {
         if (parseMethod == null)
            throw new ArgumentNullException("parseMethod");
         m_parseMethod = parseMethod;
      }
      private T foo; 
      public string a {
        set
        {
           foo = m_parseMethod(value);
        }
        get
        {
           return foo.toString();
        }
      }
     }
    class IntParse : MyParseBase<Int32>
    {
        public IntParse()
           : base (Int32.Parse)
        {}
    }
