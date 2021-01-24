    public class BaseLink 
    {
       private BaseLink Link { get; set; }
    
       protected virtual void AddLink (BaseLink obj)
       {
          Link = obj;
          Link.AddLink(obj);
    
       }
    }
    public class ObjA : BaseLink
    {
    
    } 
    
    public class ObjB : BaseLink
    {
       public void Add(BaseLink baseLink)
       {
          AddLink(baseLink);
       }
    } 
    // or
    public class ObjB : BaseLink
    {
       public ObjB(BaseLink baseLink) => AddLink(baseLink); 
    } 
