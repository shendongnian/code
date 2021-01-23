    public class NameList : ObservableCollection<PersonName>
    {
        public NameList() : base()
        {
            Add(new PersonName("A", "E"));
            Add(new PersonName("B", "F"));
            Add(new PersonName("C", "G"));
            Add(new PersonName("D", "H"));
        }
      }
    
      public class PersonName
      {
          private string firstName;
          private string lastName;
    
          public PersonName(string first, string last)
          {
              this.firstName = first;
              this.lastName = last;
          }
    
          public string FirstName
          {
              get { return firstName; }
              set { firstName = value; }
          }
    
          public string LastName
          {
              get { return lastName; }
              set { lastName = value; }
          }
      }
    
