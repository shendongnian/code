    public abstract class Entity
    {
        public virtual void OnBeforeInsert(){}
        public virtual void OnBeforeUpdate(){}
    }
    
    public class Category : Entity
    {
    
        public string Name { get; set; }
        public string UrlName{ get; set; }
    
        public override void OnBeforeInsert()
        {
           //ur logic
        }
    }
