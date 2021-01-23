    class PersonFirstOrLastNameComparer : IComparer<Person>
    {
      public int Compare( Person x, Person y )
      {
        return GetKey( x ).CompareTo( GetKey( y ) );
      }
      private String GetKey( Person person )
      {
        if ( person.FirstName.CompareTo( person.LastName ) < 0 )
        {
          return person.FirstName;
        }
        else
        {
          return person.LastName;
        }
      }
    }
