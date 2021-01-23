    public class Person
    {
        public void ChangeName(string name)
        {
           if (!IsValidName(name))
           {
               throw new ArgumentException(....);
           }
           else
              this.Name = value;
        }
        public bool IsValidName(string name)
        {
            // is the name valid using
        }
        public string Name { get; private set; }
     }
