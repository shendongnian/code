    public class Person
    {
      public Person(string name, DateTime birthday)
      {
        Name = name;
        Birthday = birthday;
      }
      public string Name { get; set; }
      public DateTime Birthday { get; set; }
      public int AgeInYears { get { return (DateTime.Now.Year - Birthday.Year); } }
      public override string ToString()
      {
        return string.Format("Person [{0}] Age [{1}]", Name, AgeInYears);
      }
    }
