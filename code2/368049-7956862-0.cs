        public interface IData<T>
        {
            bool EqualsTo(IData<T> otherData);
            T Data { get; }
        }
    
        public class MyData<T> : IData<T>
        {
            public T Data { get; private set; }
    
            public MyData(T data)
            {
                Data = data;
            }
    
            public bool EqualsTo(IData<T> otherData)
            {
                if (Data is IComparable && ((IComparable)Data).CompareTo(otherData.Data) == 0)
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
