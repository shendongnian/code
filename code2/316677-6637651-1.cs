    public class ObserverTest<T>
    {
         private static ObserverTest _obsTest;
         private Action<T> _observer;
         public static ObserverTest<T> Instance<T>()
         {
             ...
         }
         ...
    }
