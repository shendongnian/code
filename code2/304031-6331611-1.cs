        public class Entity<T>
        {
            public Entity<P> Parent
                where P : Entity<Entity<T>>
            { get; private set; }
            //
            //
            //
            public Entity(Entity<P> parent)
                where P : Entity<Entity<T>>
            {
                this.Parent = parent;
            }
        }
