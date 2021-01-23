    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication2
    {
        class Program
        {
            static normalclass c;
            static normalstruct s;
            static void Main(string[] args)
            {
                c = new normalclass() { classArg = 1 };
                s = new normalstruct() { structArg = 1 };
                EventVarPasser.BasicEvent += new EventHandler<FancyEventArgs>(EventVarPasser_BasicEvent);
                EventVarPasser.RaiseEvent(c,s);
            
            }
            static void EventVarPasser_BasicEvent(object sender, FancyEventArgs e)
            {
                Console.WriteLine("Before Messing with Eventargs");
                Console.WriteLine("Class:" + c.classArg.ToString() + "  Struct: " + s.structArg.ToString());
                e.normclass.classArg += 1;
                e.normstruct.structArg += 1;
                Console.WriteLine("After Messing with Eventargs");
                Console.WriteLine("Class :" + c.classArg.ToString() + "  Struct: " + s.structArg.ToString());
            }
        }
        static class EventVarPasser
        {
            public static event EventHandler<FancyEventArgs> BasicEvent;
            public static void RaiseEvent(normalclass nc, normalstruct ns)
            {
                FancyEventArgs e = new FancyEventArgs() { normclass = nc, normstruct = ns };        
                 BasicEvent(null, e);
            }
        
        }
        class normalclass
        {
            public int classArg;
        }
        struct normalstruct
        {
            public int structArg;
        }
        class FancyEventArgs : EventArgs
        {
            public normalstruct normstruct;
            public normalclass normclass;
        }
    }
