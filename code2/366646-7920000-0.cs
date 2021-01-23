    public class Mock : IFoo
    {
         private int _calls;
         public Mock()
         {
             _calls = 0;
         }
         public int Execute()
         {
             _calls++;
            
             if (_calls == 1)
                 throw new Exception();
             return value;
         }
    }
             
