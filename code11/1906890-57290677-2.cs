    public class Model : INotifyDataErrorInfo
    {
        public Model(int myInt, string myString)
        {
            MyInt = myInt;
            MyString = myString;
        }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public bool HasErrors
        {
            get
            {
                try
                {
                    return MyInt == 88 || MyString == "foo";
                }
                catch (Exception)
                {
                    return true;
                }
            }
        }
        public int MyInt
        {
            get { throw new NotImplementedException(); }
            set { }
        }
        public string MyString { get; set; }
        public IEnumerable GetErrors(string propertyName)
        {
            try
            {
                if (propertyName == nameof(MyInt) && MyInt == 88)
                    return new string[] { "MyInt must not be 88" };
                if (propertyName == nameof(MyString) && MyString == "foo")
                    return new string[] { "MyString must not be 'foo'" };
                return new string[0];
            }
            catch (Exception)
            {
                return new string[] { "Exception" };
            }
        }
    }
