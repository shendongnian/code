    namespace Factory
    {
        public interface IDoor { }
        public interface IEngine { }
        public interface IPropeller { }
    
        public interface IDoorProvider
        {
            ICollection<IDoor> Doors { get; }
        }
    
        public interface IEngineProvider
        {
            ICollection<IEngine> Engines { get; }
        }
    
        public interface IPropellerProvider
        {
            ICollection<IPropeller> Propellers { get; }
        }
    
        public abstract class Vehicle { }
    
        public class Car : Vehicle, IDoorProvider, IEngineProvider
        {
            public ICollection<IDoor> Doors { get; protected set; }
            public ICollection<IEngine> Engines { get; protected set; }
        }
    
        // And so on...
    }
