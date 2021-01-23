    namespace ConsoleApplication1
    {
      using System;
    
      class Program
      {
    
        static void Main()
        {
          //Using reflection:
          object obj = GetUnknownObject();
          var objType = obj.GetType();
    
          var knownInterface = objType.GetInterface("IA");
          var method = knownInterface.GetMethod("Print");
          method.Invoke(obj, new object[] { "Using reflection" });
    
          //Using DRL
          dynamic dObj = GetUnknownObject();
          dObj.Print("Using DLR");
    
          //Using a wrapper, so you the dirty dynamic code stays outside
          Marshal marshal = new Marshal(GetUnknownObject());
          marshal.Print("Using a wrapper");
    
        }
    
        static object GetUnknownObject()
        {
          return new A();
        }
      } //class Program
    
      class Marshal
      {
        readonly dynamic unknownObject;
        public Marshal(object unknownObject)
        {
          this.unknownObject = unknownObject;
        }
    
        public void Print(string text)
        {
          unknownObject.Print(text);
        }
      }
    
      #region Unknown Types
      interface IA
      {
        void Print(string text);
      }
    
      class A : IA
      {
        public void Print(string text)
        {
          Console.WriteLine(text);
          Console.ReadKey();
        }
      }
      #endregion Unknown Types
    }
