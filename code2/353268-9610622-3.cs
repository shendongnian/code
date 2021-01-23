    public class Person
        {
            private int Age;
            private string Name;
            private string HairColour;
    
    
            public Person(int theAge):this(theAge, "", "")
            {
                //One parameter
            }
    
            public Person(int theAge, string theName):this(theAge, theName, "")
            {
                //Two Parameters
            }
    
            public Person(int theAge, string theName, string theHairColour)
            {
                //Three parameters
                Age = theAge;
                Name = theName;
                HairColour = theHairColour;
            }
    
        }
    
