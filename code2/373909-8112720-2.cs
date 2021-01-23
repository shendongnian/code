     public sealed class AbstractFactory<TDataContract,T> 
          where T: class{
         static AbstractFactory(){
              Bolt = new object();
         }
         private static readonly object Bolt;
         private static AbstractFactory<TDataContract,T> Instance;
         public static AbstractFactory<TDataContract,T> GetInstance(){
              if(Instance == null){
                  lock(Bolt){
                      if(Instance == null)
                          Instance = new AbstractFactory<T>();
                  }
              }
              return Instance;
         }
         private AbstractFactory(){}
         private Func<TDataContract,T> m_FactoryMethod;
         public void Configure(Func<TDataContract,T> factoryMethod){
                  m_FactoryMethod = factoryMethod;
         }
 
         public T Create(TDataContract data) { 
                  if(m_FactoryMethod == null) {
                           throw new NotImplementedException();
                  }
                  return m_FactoryMethod.Invoke(data);
         } 
     } 
