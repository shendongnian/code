    public class MyListClass<T> : IEnumerable<T>
    {
        public delegate void MyDelegate();
        public event MyDelegate AddEvent;
        public event MyDelegate RemEvent;
        private LogFileAttribute logFileAttribute;
        List<T> list;
        public T this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }
        public void Add(T item)
        {
            list.Add(item);
            if (AddEvent != null)
            {
                AddEvent();
            }
            if (this.logFileAttribute != null)
            {
                logEvent("Add");
            }
        }
        public void Remove(T item)
        {
            list.Remove(item);
            if (RemEvent != null)
            {
                RemEvent();
            }
            if (this.logFileAttribute != null)
            {
                logEvent("Remove");
            }
        }
        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
            if (RemEvent != null)
            {
                RemEvent();
            }
            if (this.logFileAttribute != null)
            {
                logEvent("RemoveAt");
            }
        }
        public MyListClass()
        {
            list = new List<T>();
            checkLogFileAttribute();
        }
        public MyListClass(List<T> list)
        {
            this.list = list;
            checkLogFileAttribute();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
        private void logEvent(string methodName)
        {
            if (this.logFileAttribute.Append)
            {
                File.AppendAllLines(this.logFileAttribute.Path, new string[] { methodName + " called." });
            }
            else
            {
                File.WriteAllLines(this.logFileAttribute.Path, new string[] { methodName + " called." });
            }
        }
        private void checkLogFileAttribute()
        {
            Type t = typeof(T);
            object[] attributes = typeof(T).GetCustomAttributes(typeof(LogFileAttribute), false);
            if (attributes.Length > 0)
            {
                this.logFileAttribute = (LogFileAttribute)attributes[0];
            }
        }
    }
