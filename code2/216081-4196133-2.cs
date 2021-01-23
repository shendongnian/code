    public class Program
    {
        static void Main(string[] args)
        {
            List<IEntity> entities = new List<IEntity>();
            entities.Add(new Mirror(1));
            entities.Add(new Mirror(2));
            entities.Add(new LightBeam(1));
            entities.Add(new LightBeam(2));
            //I also fixed your for-loops, you don't need to do entities.Count - 1
            for (int i = 0; i < entities.Count; i++)
            {
                for (int j = i + 1; j < entities.Count; j++)
                {
                    Collide(entities[i], entities[j]);
                }
            }
            Console.ReadLine();
        }
        public static void Collide(IEntity e0, IEntity e1)
        {
            dynamic dyn0 = e0;
            dynamic dyn1 = e1;
            Collide(dyn0, dyn1);
        }
        public static void Collide(Entity e0, Entity e1)
        {
            Console.WriteLine("Collision: IEntity {0}[{1}] and IEntity {2}[{3}].", e0.Name, e0.ID, e1.Name, e1.ID);
        }
        public static void Collide(Mirror m0, LightBeam lb0)
        {
            Console.WriteLine("Special Collision: Mirror {0}[{1}] and LightBeam {2}[{3}].", m0.Name, m0.ID, lb0.Name, lb0.ID);
        }
    }
    //Interfaces are our friends :)
    public interface IEntity
    {
        String Name { get; }
        Int32 ID { get; }
    }
    public abstract class Entity : IEntity
    {
        protected Entity(Int32 id = 0)
        {
            ID = id;
        }
        public Int32 ID { get; private set; }
        public abstract String Name { get; }
    }
    public class Mirror : Entity
    {
        public Mirror(Int32 id = 0)
            : base(id)
        {
        }
        public override String Name
        {
            get { return "Mirror"; }
        }
    }
    public class LightBeam : Entity
    {
        public LightBeam(Int32 id = 0)
            : base(id)
        {
        }
        public override String Name
        {
            get { return "LightBeam"; }
        }
    }
