    namespace Factory
    {
        public interface IDoor { }
        public interface IEngine { }
        public interface IPropeller { }
    
        public abstract class Vehicle
        {
            public ICollection<IDoor> Doors { get; protected set; }
            public ICollection<IEngine> Engines { get; protected set; }
        }
        public class Airplane : Vehicle
        {
            public ICollection<IPropeller> Propellers { get; protected set; }
        }
    }
