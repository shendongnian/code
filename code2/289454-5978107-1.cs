    public class ComponentAttributeDto
    {
      public virtual ComponentAttributeDto ParentComponentAttributeDto { get; private set; }
      public virtual ComponentAttributeDto Root 
      { 
         get 
         {
           if (ParentComponentAttributeDto == null) 
           {
             return this;
           }
           else 
           {
             return ParentComponentAttributeDto.Root;
           }
         }
         private set
         { /* just for NH to call it */ }
      }
      // ....
    }
