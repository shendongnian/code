    class Spec : IComparable<Spec>, IComparable
    {
      public property Name
      {
         get { /* code I don't care about here*/ }
         set { /* code I don't care about here*/ }
      }
      /* more code I don't care about here*/
      public int CompareTo(Spec other)
      {
         if(other == null)
           return 1;
         //Often we make use of an already-existing comparison, though not always
         return string.Compare(Name, other.Name, StringComparison.InvariantCultureIgnoreCase)
      }
      //For backwards compatibility:
      public int CompareTo(object other)
      {
        if(other == null)
          return 1;
        Spec os = other as Spec;
        if(os == null)
          throw new ArgumentException("Comparison between Spec and " + other.GetType().FullName + " is not allowed");
        return CompareTo(os);
      }
    }
