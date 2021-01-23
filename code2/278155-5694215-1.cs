    class Person
    {
        public int Id;
        public string Name;
        public DateTime BirthDate;
        public U GetColumnVal<U>(Func<Person, U> Lambda)
        {
            return Lambda(this);
        }
    }
