    public class Person {
    
        private string firstName;
        private string lastName;
        
        public Person(string firstName, string lastName) {
            
            //How could you set the first name passed in the constructor to the local variable if both have the same?
            this.firstName = firstName;
            this.lastName = lastName;
        }
    
        //...
    }
