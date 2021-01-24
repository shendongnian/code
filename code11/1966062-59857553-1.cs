    public class Entity<TControl> where TControl : Control, new()
    {
       public float Rotate {get; private set;}
    
       readonly TControl m_Control;
    
       public Entity(float rot)
       {
           Rotate = rot;
           m_control = new TControl();
       }
    }
    public abstract class Control {}
    public class PlayerControl : Control {}
    public class AIControl : Control {}
    public class Environment
    {
    
        readonly Entity<PlayerControl> m_entity;
        readonly Entity<AIControl> m_entity2;
    
        public Environment()
        {
           m_entity = new Entity<PlayerControl>(90.0f);
           m_entity2 = new Entity<AIControl>(180.0f);
        }
    }
