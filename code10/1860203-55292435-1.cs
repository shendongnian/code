    public class Movie 
    {
       // ...
    
       public virtual ICollection<MovieDisc> Discs {get; internal set;} = new List<MovieDisc>();
       public byte NumberInStock 
       { 
          get { return Discs.Count(x => x.InStock); }
       }
    
       public byte NumberAvailable 
       { 
          get { return Discs.Count(x => !x.InStock); }
       }
    }
