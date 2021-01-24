    public class Employee<T> where T : IInputRow<T>
    {
        public List<T> list;
        public Employee()
        {
            list = new List<T>();
        }
    }
