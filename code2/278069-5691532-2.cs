    class Program
    {
        public static void Main()
        {
            var shadowCasters = new List<ICastShadow>();
    
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
    
        public class Car : ICastShadow
        {
            public void DrawShadow(object device)
            {
                Console.WriteLine("Car Shadow!");
            }
        }
    
        public class Plane : ICastShadow
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
