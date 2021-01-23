    public class Student : IComparable
    {
        private string message = null;
        public Student(string message)
        {
            this.message = message;
        }
        #region IComparable Members
        public int CompareTo(object obj)
        {
            // implement your logic, here is a example:
            if (obj != null)
                return message.CompareTo(((Student)obj).message);
            return int.MinValue;
        }
        #endregion
    }
