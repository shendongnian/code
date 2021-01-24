using System;
using System.Collections.Generic;
namespace GenericsMixingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            container.Wrappers.Add(new IntProcessor { Value = 5 });
            container.Wrappers.Add(new IntProcessor { Value = 5 });
            container.Wrappers.Add(new StringProcessor { Value = "value" });
            container.Wrappers.ForEach((e) => { e.Process(); });
        }
    }
    interface IProcessor
    {
        void Process();
    }
    class IntProcessor : IProcessor
    {
        public int Value { get; set; }
        public void Process()
        {
            Console.WriteLine("Processing: " + Value);
        }
    }
    class StringProcessor : IProcessor
    {
        public string Value { get; set; }
        public void Process()
        {
            Console.WriteLine("Processing: " + Value);
        }
    }
    interface IContainer
    {
        List<IProcessor> Wrappers
        {
            get;
            set;
        }
    }
    class Container : IContainer
    {
        public List<IProcessor> Wrappers
        {
            get;
            set;
        }
    }
}
