    public class Person
    {
        private string _name;
        
        public string setName(string newName)
        {
            this._name = newName;
        }
        public string getName()
        {
            return this._name;
        }
    
        }
    
    Person person = new Person();
    person.setName("Andre");
