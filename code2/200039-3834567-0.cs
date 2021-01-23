    sealed class ContactFirstNameLastNameComparer : IEqualityComparer<Contact>
    {
      public bool Equals (Contact x, Contact y)
      {
         return x.firstname == y.firstname && x.lastname == y.lastname;
      }
      public int GetHashCode (Contact obj)
      {
         return obj.firstname.GetHashCode () ^ obj.lastname.GetHashCode ();
      }
    }
