    public class PartAssemblyItem
    {
      public virtual int PartID { get; set; }
      public virtual int AssemblyItemPartID { get; set; }
      public virtual int Status { get; set; }
      public virtual string Coding { get; set; }
      // public virtual string Name { get; set; } <--- DELETED THIS
      // Then added this:
      public virtual Part Part { get; set; }
    
      public override bool Equals(object obj) { .. snipped .. }
      public override int GetHashCode() { .. snipped .. }
    }
