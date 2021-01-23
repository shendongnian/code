    public class Person : IComparable<Person>, IComparer<Person>
    {
        public string Titel { get; set; }
    
        public string FirstName { get; set; }
    
        public string LastName { get; set; }
    
        public DateTime? SomeOptionalValue { get; set; }
    
        int IComparer<Person>.Compare(Person x, Person y)
        {       
            return (x as IComparable).CompareTo(y);
        }
    
        int IComparable<Person>.CompareTo(Person other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));
            int result = this.Titel.CompareTo(other.Titel);
    
            //chain the other properties in the order you'd like to
            //have them sorted. 
            if (result == 0)
                result = this.FirstName.CompareTo(other.FirstName);
    
            if (result == 0)
                result = this.LastName.CompareTo(other.LastName);
    
            //use optional values as well as call the compare implementation on a class
            if (result == 0 && SomeOptionalValue.HasValue && other.SomeOptionalValue.HasValue)
                result = DateTime.Compare(this.SomeOptionalValue.Value, other.SomeOptionalValue.Value);
    
            return result;
        }
    }
  
