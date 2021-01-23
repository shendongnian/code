    using System;
    using System.Reflection;
    
    [assembly: AssemblyVersion("1.0.*")]
    
    namespace myNameSpace
    {
      public class RD_ToBeProcessed : ToBeProcessed
      {
        public RD_ToBeProcessed(string data) { this.data = data; }
      }
    }
