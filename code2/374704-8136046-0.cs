    using System;
    using System.Reflection;
    
    [assembly: AssemblyVersion("1.0.*")]
    
    namespace myNameSpace
    {
      public class ToBeProcessed
      {
        protected string data;
        public ToBeProcessed() { }
        public string Process() { return data.ToUpper(); }
      }
    }
