    class Program
    {
        public static void Main()
        {
            var shadowCasters = new List<IShadowCaster>();
    
            shadowCasters.Add(new Car());
            shadowCasters.Add(new Plane());
    
            var castShadows = true;
    
            if (castShadows)
            {
                foreach (var caster in shadowCasters)
                {
                    caster.DrawShadow(null); 
                }
            }
    
            Console.Read();
        }
    
        public class Car : IShadowCaster
        {
            public void DrawShadow(object device)
            {
                Console.WriteLine("Car Shadow!");
            }
        }
    
        public class Plane : IShadowCaster
        {
            public void DrawShadow(object device)
            {
                Console.WriteLine("Plane Shadow!");
            }
        }
    
        public interface IShadowCaster
        {
            void DrawShadow(object device);
        }
    }
