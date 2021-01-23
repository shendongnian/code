    private class Person {
        private int _age;  // Person._age = 25; will through an error
        public int Age{
            get { return _age; }  // example: Console.WriteLine(Person.Age);
            set { 
                if ( value >= 0) {
                    _age = value; }  // valid example: Person.Age = 25;
            }
        }
    }
