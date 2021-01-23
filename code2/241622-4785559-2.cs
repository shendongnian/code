    public class Singleton {
     
        private static final Singleton INSTANCE = new Singleton();
        private Object FactoryOutput;
        // Private constructor prevents instantiation from other classes
        private Singleton() {
        }
     
        public static Singleton getInstance() {
            return INSTANCE;
        }
        public Object SomeClassWhichNeedsSingleInstantiation(Object Parameter) 
        {
        If(FactoryOutput == null)
          { 
          FactoryOutput = new FactoryOutput(Parameter);
          }
        return FactoryOutput;    
        } 
    }
