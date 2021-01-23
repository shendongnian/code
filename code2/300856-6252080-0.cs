    public interface IData {
        type Type { get; set; }
        string Name { get; set; }
        T GetValue<T>();
    }
    public class Data<T> : IData
    {
        public Type Type { get; set; }
        public string Name { get; set; }
        public T Value { get; set; }
        public Tret GetValue<Tret>() {
            return (Tret)(Object)Value;
        }
    }
