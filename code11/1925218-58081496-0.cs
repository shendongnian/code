    public class PersonMoodHandler
    {
        public Person MakeHappy(Person person)
        {
            person.HappinessLevel = 10;
            person.Comments = "Happy Now";
            return person;    		
        }
    }
    public class Test
    {
        public void DoStuffWithPerson()
        {
            Person person = new Person { Name = "Joe" };
            PersonMoodHandler personMoodHandler = new PersonMoodHandler();
            WritePersonComments(personMoodHandler.MakeHappy(person));
         }
    }
