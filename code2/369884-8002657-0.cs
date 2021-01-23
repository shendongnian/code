     public class Person : IComparable
        {
            public int age { get; set; }
            public int CompareTo(object obj)
            {
                var person = obj as Person;
                if (person != null)
                {
                    if (age > person.age)
                        return 1;
                    else if (age == person.age)
                        return 0;
                    return -1;
                }
                return 1;
            }
        }
