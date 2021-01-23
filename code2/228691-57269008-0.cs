    public class Person : IComparer<Person>
    {
        public string Titel { get; set; }
    
        int IComparer<Person>.Compare(Person x, Person y)
        {
            if (x is null)
                throw new ArgumentNullException(nameof(x));
            if (y is null)
                throw new ArgumentNullException(nameof(y));
    
            return x.Titel.CompareTo(y.Titel);                      
        }
    }
