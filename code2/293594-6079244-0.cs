    class Program
    {
        static void Main()
        {
            List<Person> persons = new List<Person>
                                    {
                                        new Person {Name = "John", Age = 24},
                                        new Person {Name = "Tom", Age = 35},
                                        new Person {Name = "Mike", Age = 42},
                                        new Person {Name = "Steve", Age = 51}
                                    };
            //{Phil, 45}
            persons.Between(age: 45);
        }
    }
    public static class AgeExtensionMethod
    {
        public static Person[] Between(this List<Person> person,int age)
        {
            var orderdList = person.OrderBy(p => p.Age);
            var k = orderdList.Where(p => p.Age < age).Last();
            var s = orderdList.Where(p => p.Age > age).First();
            return new[] {k, s};
        }
    }
