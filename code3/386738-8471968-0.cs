    public class Persons
    {
       public string Name { get; set; }
       //NAVIGATIONL PROP. 
       public virtual ICollection<streetLivedIn> Streets { get; set }
    }
