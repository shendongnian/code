    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MamdaAdapter;
    using System.Reflection;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                IExchange SelectedExchange = Exchange.DeriveExchange("MamdaAdapter.Arca");
                Console.WriteLine(SelectedExchange.GetTransport());
            }
        }
    }
    
    namespace MamdaAdapter
    {
        public interface IExchange
        {
            string GetTransport();
        }
    }
    
    
    namespace MamdaAdapter
    {
        public class Arca : IExchange
        {
            private const string _Transport = "tportname";
    
            public string GetTransport()
            {
                return _Transport;
            }
        }
    }
    
    namespace MamdaAdapter
    {
        public class Exchange
        {
            public static IExchange DeriveExchange(string ExchangeName)
            {
                IExchange SelectedExchange = (IExchange)Assembly.GetAssembly(typeof(IExchange)).CreateInstance(ExchangeName, false, BindingFlags.CreateInstance, null, null, null, null);
                return SelectedExchange;
            }
        }
    
    }
