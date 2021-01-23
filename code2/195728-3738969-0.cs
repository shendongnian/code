    public class DALFactory
    {
       private Dictionary<Type, Func<DBBase>> factoryMethods;
    
       public void Register(Type type, Func<DBBase>> producer)
       {
          factoryMethods[type] = producer; //last-in wins
       }
       
       public DBBase GetObject(Type type)
       {
           if(factoryMethods.ContainsKey(type))
              return factoryMethods[type]();
           return null; //or throw exception
       }
       public Func<DBBase> GetFactoryMethod(Type type)
       {
           if(factoryMethods.ContainsKey(type))
              return factoryMethods[type];
           return null; //or throw exception
       }
    }
    ...
    var factory = new DALFactory();
    factory.Register(typeof(PersonDB), ()=>new PersonDB());
    //Register other named or anonymous factory methods that produce objects
