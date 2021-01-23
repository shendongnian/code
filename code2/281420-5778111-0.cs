    private static List<Person> people = new List<Person>();
        static void Main(string[] args)
        {
            // add some people
            people.Add(
                new Person() { firstName = "John", familyName = "Smith", sex = Sex.Male, age = 12 }
                );
            people.Add(
                new Person() { firstName = "Mary", familyName = "Doe", sex = Sex.Female, age = 25 }
                );
            // write the data
            Write();
        }
        static void Write()
        {
            using (TextWriter tw = new StreamWriter(@"c:\junk1\test.csv", false))
            {
                // write the header
                tw.WriteLine("Family Name, First Name, Sex, Age");
                // write the details
                foreach(Person person in people)
                {
                    tw.WriteLine(String.Format("{0}, {1}, {2}, {3}", person.familyName, person.firstName, person.sex.ToString(), person.age.ToString()));
                }
            }
        }
    }
    /// <summary>
    ///  Applicable sexes
    /// </summary>
    public enum Sex
    {
        Male,
        Female
    }
    /// <summary>
    /// holds details about a person
    /// </summary>
    public class Person
    {
        public string familyName { get; set; }
        public string firstName { get; set; }
        public Sex sex { get; set; }
        public int age { get; set; }
    }
