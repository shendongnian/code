    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                ObserverTest<int> obs = ObserverTest<int>.Instance();
                obs.SubscribeToChange<int>(GotChange);
                obs.NotifyChange<int>(200);
                Console.ReadLine();
            }
    
            private static void GotChange(int val)
            {
                Console.WriteLine(string.Format("Changed value is {0}", val));
            }
        }
    
        public class ObserverTest<T>
        {
            private static ObserverTest<T> _obsTest;
            private Action<T> _observer;
    
            private ObserverTest()
            {
            }
    
            public static ObserverTest<T> Instance()
            {
                return _obsTest = _obsTest == null ? new ObserverTest<T>() : _obsTest;
            }
    
            public void NotifyChange<E>(T val)
            {
                _observer(val);
            }
    
            public void SubscribeToChange<E>(Action<T> observer)
            {
                _observer = observer;
            }
    
        }
    }
