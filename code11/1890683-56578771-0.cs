    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Threading;
    class Program
    {
        static Program()
        {
            Program.ConsolePrint("Program Static Constructor");
        }
        static void Main(string[] args)
        {
            ConsolePrint("Starting Tasks");
            var tasks = Enumerable.Range(1, 5).Select(n => Task.Run(() =>
            {
                new Foo(n.ToString());
            })).ToArray();
            ConsolePrint("Waiting Tasks");
            Task.WaitAll(tasks);
            ConsolePrint("Tasks Finished");
            //Console.WriteLine("Foo.list: " + String.Join(", ", Foo.GetItems()));
        }
        public static void ConsolePrint(string line)
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + " ["
                + Thread.CurrentThread.ManagedThreadId.ToString() + "] > " + line);
        }
    }
    public class Foo
    {
        static Foo()
        {
            Program.ConsolePrint("Foo Static Constructor");
        }
        private static List<string> list = new List<string>();
        private static object listLock = new SlowObject();
        public Foo(string s)
        {
            Program.ConsolePrint("Creating Foo " + s);
            lock (listLock)
            {
                list.Add(s);
            }
        }
    }
    public class SlowObject
    {
        static SlowObject()
        {
            Program.ConsolePrint("SlowObject Static Constructor");
        }
        public SlowObject()
        {
            Program.ConsolePrint("SlowObject Instance Constructor Started");
            Thread.Sleep(500);
            Program.ConsolePrint("SlowObject Instance Constructor Finished");
        }
    }
