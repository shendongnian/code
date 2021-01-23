     interface IEntity
    {
        int Id{get;}
    } 
    interface IPerson : IEntity
    {
    
    }
    interface ITeacher : IPerson 
    {
    
    }
    interface IStudent : IPerson 
    {
   
    }
    interface IDataContext
    {
        T Get<T>(int id) where T:new();
    }
    interface IRepository  
    {
        T Get<T>(int id) where T : IEntity , new() ;
    }
 
    public class EntityBase : IEntity
    {
       public virtual int Id{get;set;}
    }
    public class Teacher : EntityBase, ITeacher {
        int id=0;
        public override int Id { 
        
                        get { return this.id; }
                        set { this.id = value; } 
                     }
    }
    public class Student : EntityBase, IStudent 
    {
        int id=0;
        public override int Id {
    
                        get { return this.id; }
                        set { this.id = value; } 
                      }
    }
    class Context<T>: IDataContext where T: EntityBase,  new() 
    {
        ArrayList store;
      
        public Context(int dataSize) 
        {
             store = new ArrayList(dataSize);
            for (int i = 0; i < dataSize; i++)
            {
            
                T t = new T();
                t.Id = i;           
                store.Add(t);
            
            }
    
        }    
        public T Get<T>(int i) where T:new()
        {
            if (i<store.Count)
            {   
                return (T)store[i]; 
            }
            else
            {
                return default(T);
            }
    
        }
    }
