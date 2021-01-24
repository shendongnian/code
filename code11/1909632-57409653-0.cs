    using System;
    using System.Reactive.Linq;
    
    namespace RxTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var observable = "abcd".ToObservable()
                    .Select((c, i) => i == 0 ? c.ToString() : $",{c}");
    
                observable.Subscribe(Console.Write); 
            }
        }
    }
