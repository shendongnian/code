    public class Person
    {
        private int _age;
        public int _phoneNumber;
        // protected int _futureInt;
        Dictionary<string, string> _readingList = new Dictionary<string, string>();
        public Person(int age){
            _age = age;
        }
        public bool personProperty
        {
            get
            {
                List<bool> resultList = new List<bool>();
                var intFields = this.GetType().GetFields(BindingFlags.Instance | 
                                                         BindingFlags.NonPublic | 
                                                         BindingFlags.Public)
                                              .Where(f => f.FieldType == typeof(int))
                                              .Select(f => f.GetValue(this)).Cast<int>();
                foreach (int personFieldValue in intFields)
                {
                    bool result = personMethod(personFieldValue);
                    resultList.Add(result);
                }
                // Do stuff with `resultList` that'll initialize personPropertyReturnValue;
                bool personPropertyReturnValue = resultList.All(b => b);
                return personPropertyReturnValue;
            }
        }
        private bool personMethod(int arg)
        {
            return (arg > 0);
        }
    }
