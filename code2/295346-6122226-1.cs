        public class MyDerivedClass : BasicTestApp.FirstApi.MyBaseClass, BasicTestApp.SecondApi.IMyInterface
        {
            IEnumerable<T> SecondApi.IMyInterface.Search<T>()
            {
                // do implementation
            }
        }
