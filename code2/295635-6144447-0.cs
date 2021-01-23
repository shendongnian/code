    public interface IExploding { int ExplosionRadius { get; } }
    
    public class Grenade : IExploding { public int ExplosionRadius { get { return 30; } } ... }
    
    public class StinkBomb : IExploding { public int ExplosionRadius { get { return 10; } } ... }
    
    public static class Extensions
    {
        public static int Damages(this IExploding explosingObject)
        {
            return explosingObject.ExplosionRadius*100;
        }
    }
