    public interface ISelectedVal
    {
        Object Val { get; set; }
    }
    public class SelectedVal<T> : ISelectedVal
    {
        public T Val { get; set; }
        object ISelectedVal.Val
        {
            get => this.Val;
            set => this.Val = (T)value;
        }
    }
    public class StringVal : SelectedVal<String>
    {
    }
    public class IntVal : SelectedVal<int>
    {
    }
