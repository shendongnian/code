    namespace Yesod
    {
        public class Program
        {
            //
            //
            //
            public struct Particle
            {
                public byte type;
            }
            // Fix with C# 4.0 using out keyword.
            //
            //
            public interface IEntity<out T>
            {
                IEntity<IEntity<T>> Parent
                { get; }
            }
            //
            //
            //
            public class Entity<T> : IEntity<T>
            {
                public IEntity<IEntity<T>> Parent
                { get; private set; }
                //
                //
                //
                public Entity(IEntity<IEntity<T>> parent)
                {
                    this.Parent = parent;
                }
            }
            //
            //
            //
            public sealed class Atom : Entity<Particle>
            {
                public Atom(Entity<Atom> parent)
                    : base(parent) // No more compile error.
                { }
            }
            //
            //
            //
            public sealed class Molecule : Entity<Atom>
            {
                public Molecule()
                    : base(null)
                { }
            }
   
            //
            //
            //
            static void Main(string[] args)
            {
                // Now this can be done.
                Molecule water = new Molecule();
                Atom H1 = new Atom(molecule);
                Atom O1 = new Atom(molecule);
                Atom O2 = new Atom(molecule);
            }
        }
    }
