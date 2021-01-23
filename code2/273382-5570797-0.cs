        public class Person
        {
            public string Name { get; set; }
            public string FamilyName { get; set; }
            public int Age { get; set; }
        }
        public class PersonComparer : IComparer<KeyValuePair<string, Person>>
        {
            public int Compare(KeyValuePair<string, Person> x, KeyValuePair<string, Person> y)
            {
                var result = x.Value.FamilyName.CompareTo(y.Value.FamilyName);
                if(result != 0)
                    return result;
                return x.Value.Age.CompareTo(y.Value.Age);
            }
        }
