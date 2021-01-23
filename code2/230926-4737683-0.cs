    HasMany (x => x.ChildReferences).Cascade.All ();
    
    public class ChildReference 
        {
            public virtual int ChildId { get; set; }
        }  
...
