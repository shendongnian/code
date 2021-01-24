    public class Car
    {
     public int CarId{ get; set; }
     public Owner CurrentOwner { get; set; }
     public ICollection<Owner> PreviousOwners { get; set; }
    }
