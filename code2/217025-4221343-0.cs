    public class Person : IEquatable<Person>
    {
      /* more stuff elided */
    
      public bool Equals(Person other)
      {
        return !ReferenceEquals(other, null) &&
          SocialSecurityNumber == other.SocialSecurityNumber &&
          FirstName == other.FirstName &&
          LastName == other.LastName;
      }
      public override bool Equals(object obj)
      {
        return Equals(obj as Person);
      }
      public static bool operator !=(Person person1, Person person2)
      {
        return !(person1 == person2);
      }
      public static bool operator ==(Person person1, Person person2)
      {
        return ReferenceEquals(person1, person2)
          || (!ReferenceEquals(person1, null) && person1.Equals(person2));
      }
    }
