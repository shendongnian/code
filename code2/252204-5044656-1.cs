    class GoodClass
    {
         Dictionary<int, BaseClass> _consoleWriters;
    
         public GoodClass( IEnumerable<BaseClass> writers )
         {
             foreach (var writer in writers) 
                _consoleWriters.Add( writer.ParamSupported, writer);
         }
         void DoSth(int param)
         {
             _consoleWriters[ param ].DoSth();
         }
    }
    
    abstract class BaseClass
    {
        abstract int ParamSupported {get;}
        abstract void DoSth(int param);
    }
    
    class ZeroWriter : BaseClass
    {
         override int ParamSupported {get{return 0;}}
         override DoSth(int param) { Console.WriteLine("param is 0"); }
    }
    
    class OneWriter : BaseClass
    {
         override int ParamSupported {get{return 1;}}
         override DoSth(int param) { Console.WriteLine("param is 1"); }
    }
