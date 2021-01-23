    internal class MyClassFactory 
    {
        internal static T Create<T>(string args) where T : IMyType
        {
            IMyType newThing = (T)typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, Type.EmptyTypes, null).Invoke(null); 
            newThing.Initialise(args);
            return (T)newThing; 
        }
    }
    public interface IMyType 
    {
        void Initialise(string args); 
    }
    public class ThingA : IMyType
    {
        private ThingA() { }
        public void Initialise(string args)
        {
            Console.WriteLine(args);
        }
    } 
