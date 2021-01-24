        public class Person
        {
            public long Age { get; set; }
        }
        static void Main(string[] args)
        {
            IEnumerable<Person> list;
            list = new Father();
            ((Father)list).Age = 5;
        }
        public class Father : Person, IEnumerable<Person>
        {
            public IEnumerator<Person> GetEnumerator()
            {
                throw new NotImplementedException();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }
