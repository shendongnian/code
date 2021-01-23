    using System; 
    using System.Runtime.InteropServices; 
     
    namespace comclient 
    { 
      class Program 
      { 
        static void Main(string[] args) 
        { 
          ComServerDemo csdObj = new ComServerDemo(); 
          IComServerDemo csd = (IComServerDemo)csdObj; 
          csd.SayHello("Bob"); 
        } 
      } 
    }
    namespace comserver
    { 
      [ComImport, Guid("8FDB8319-6EC3-45b4-A384-1403D3993A07")] 
      public class ComServerDemo 
      { 
      } 
     
      [ComImport, Guid("49752A5D-4CAD-495f-A220-07B60CDB6CE8")] 
      interface IComServerDemo 
      { 
        void SayHello(string name); 
      } 
    }
