     public class Session { 
          public static readonly AbstractFactory<Session> Factory = AbstractFactory<Session>.GetInstance();
     }
     public sealed class AbstractFactory<T> 
         where T: class{
         
         static AbstractFactory(){
              Bolt = new object();
         }
         private static readonly object Bolt;
         private static AbstractFactory<T> Instance;
         public static AbstractFactory<T> GetInstance(){
              if(Instance == null){
                  lock(Bolt){
                      if(Instance == null)
                          Instance = new AbstractFactory<T>();
                  }
              }
              return Instance;
         }
         private AbstractFactory(){}
         private Func<T> m_FactoryMethod;
         public void Configure(Func<T> factoryMethod){
                  m_FactoryMethod = factoryMethod;
         }
 
         public T Create() { 
                  if(m_FactoryMethod == null) {
                           throw new NotImplementedException();
                  }
                  return m_FactoryMethod.Invoke();
         } 
     } 
