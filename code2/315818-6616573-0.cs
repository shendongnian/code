    namespace MyNameSpace {
        public class Person {
            public string name { get; set; }
            public int age { get; set; }
        }
    
        public class MyClass {
            private static List<Person> people = new List<Person> {
                new Person {name = "name1", age=10},
                new Person {name = "name2", age=20},
                new Person {name = "name3", age=30},
                new Person {name = "name4", age=40},
                new Person {name = "name5", age=50}
            };
    
            public static IEnumerable<Person> GetPeople() {
                foreach (var p in people) {
                    yield return p;
                }
            }
        }
    }
