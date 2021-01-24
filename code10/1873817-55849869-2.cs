    using System;
    namespace Test
    {
        public class Test
        {
            public IVehicle CreateObjectType(JToken token)
            {
                switch(token["type"].Value<string>())
                {
                    case "Car":
                        return new Car();
                    case "Boat":
                        return new Boat();
                    default:
                        throw new NotImplementedException();
                }
            }
        }
        public class Boat : IVehicle { }
        public class Car : IVehicle { }
        public interface IVehicle { }
    }
