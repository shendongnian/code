       class Person
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
    
            public int FirstName
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
    
    
            public int FirstName
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
        }
.
    class Persons
    {
        private List<Person> gListOfPerson;
    
        public List<Person> All
        {
            get
            {
                if (gListOfPerson == null)
                {
                    gListOfPerson= new List<Persons>;
                }
                return gListOfPerson;
            }
            set
            {
                gListOfPerson=value;
            }
        }
    
    }
     public Persons ReturnData()
    {
                DataSet dataSet = new DataSet();
                //get data from SQL Server or what ever in a DataSet...
                 
                
                //...loop to the dataset and create new Persons
    
    
                return Persons;
    }
