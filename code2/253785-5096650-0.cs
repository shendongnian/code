    public abstract class ParentExtended : Parent  
    {  
       [InverseProperty("Parent")]    
       public ICollection<ChildClass> ChildClassList { get; set; }  
    }
