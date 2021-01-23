    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication40 {
      internal class Program {
        private static List<BaseRegister> storage=new List<BaseRegister>();
    
        private static void Main(string[] args) {
          storage.Add(new BaseRegister {dirty=true});
          storage.Add(new BaseRegister {dirty=false});
          storage.Add(new BaseRegister {dirty=true});
          Dump("---Before---");
          storage.First(item => item.dirty==true).dirty=false;
          Dump("---After---");
        }
    
        private static void Dump(string title) {
          Debug.WriteLine(title);
          foreach(var br in storage) {
            Debug.WriteLine(br.dirty);
          }
        }
    
        private class BaseRegister {
          public bool dirty { set; get; }
        }
      }
    }
    
