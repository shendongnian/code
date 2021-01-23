    public interface IStack
    {   
        bool IsEmpty();
        int Pop();
        void Push(int element);
        int Size { get; set; }
        int Top();
    }   
    public class Empty : Exception
    {
    }
