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
                if (_data is IComparable 
                    && otherData is MyData<T> 
                    && ((IComparable)_data).CompareTo(((MyData<T>)otherData)._data) == 0)
                {  
                    return true;
                }
                return false;
            }
        }
        static void Main(string[] args)
        {
    
            MyData<int> myInts1 = new MyData<int>(5);
            MyData<int> myInts2 = new MyData<int>(5);
            MyData<int> myInts3 = new MyData<int>(10);
            MyData<string> myString1 = new MyData<string>("Hello");
            MyData<string> myString2 = new MyData<string>("Hello");
            MyData<string> myString3 = new MyData<string>("World");
            if (myInts1.EqualsTo(myInts2)) Console.WriteLine("Yay");
            if (!myInts1.EqualsTo(myInts3)) Console.WriteLine("Nay");
            if (myString1.EqualsTo(myString2)) Console.WriteLine("Yay");
            if (!myString1.EqualsTo(myString3)) Console.WriteLine("Nay");
        }
