    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Logic;
    namespace ScriptRunner
    {
    class Program
    {
        static void Main(string[] args)
        {
            var runMyScript = new RunScript();
            Console.WriteLine(runMyScript.Start());
        }
      }
    }
