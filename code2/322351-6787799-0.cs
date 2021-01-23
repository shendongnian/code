    internal static class MyClassFactory
    {
        internal static T Create<T>(string args) where T : IMyType
        {
            IMyType newThing = 
               (T)typeof(T).GetMethod("GetInstance").Invoke(default(object), null); 
            newThing.Initialise(args);
            return (T)newThing; 
        }
    }
    public interface IMyType 
    {
        void Initialise(string args); 
    }  
    public class ThingA: IMyType 
    {
        private ThingA() { }
        public static IMyType GetInstance()
        {
            return new ThingA(); 
        }
        public void Initialise(string args) 
        {   
            // do something with args 
        } 
    } 
