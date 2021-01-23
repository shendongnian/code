        public interface IData<T>
        {
            bool EqualsTo(IData<T> otherData);
        }
    
        public class MyData<T> : IData<T>
        {
            private T _data;
    
            public MyData(T data)
            {
                _data = data;
            }
    
            public bool EqualsTo(IData<T> otherData)
            {
                if (_data is IComparable && ((IComparable)_data).CompareTo(((MyData<T>)otherData)._data) == 0)
                    return true;
                return false;
            }
        }
        static void Main(string[] args)
        {
    
            MyData<int> myInts1 = new MyData<int>(5);
            MyData<int> myInts2 = new MyData<int>(5);
            MyData<int> myInts3 = new MyData<int>(10);
            if (myInts1.EqualsTo(myInts2)) Console.WriteLine("Yay");
            if (!myInts1.EqualsTo(myInts3)) Console.WriteLine("Nay");
        }
