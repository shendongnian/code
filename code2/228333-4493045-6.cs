      public class Person
        {
            private int gID;
            private String gFirstName="";
            private String gLastName = "";
    
    
            public int ID
            {
                get 
                {
                    return gID;
                }
                set
                {
                    gID = value;
                }
            }
    
            public String FirstName
            {
                get
                {
                    return gFirstName;
                }
                set
                {
                    gFirstName= value;
                }
            }
    
    
            public String LastName
            {
                get
                {
                    return gLastName;
                }
                set
                {
                    gLastName = value;
                }
            }
        }
.
       public class Persons
        {
            private List<Person> gListOfPerson;
        
            public List<Person> All
            {
                get
                {
                    if (gListOfPerson == null)
                    {
                        gListOfPerson= new List<Person>();
                    }
                    return gListOfPerson;
                }
                set
                {
                    gListOfPerson=value;
                }
            }
        
        }
