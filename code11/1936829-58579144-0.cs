        public class Traindrivers : Persons
        {
            protected static int id=0;
        //             ^^^^         ^^
            //protected static int mycounter;
        
            public Traindrivers(/*int id,*/ string firstname, string lastname, string email, int age) : base(firstname, lastname, email, age)
    //                          ^^^^^^^^^
            {
                //mycounter++;
                //id = mycounter;
                id++;
            }
        
        
            public int LicensNumber
            {
                get { return id; }
                set { id = value; }
            }
        
            public override string ToString()
            {
                return LicensNumber + FirstName + LastName + Email + Age;
            }
        }
