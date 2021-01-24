    public class EntityHandlerA
    {
        private readonly EntityA _entityA;
        private readonly TaskEntityA _taskEntityA;
        public EntityHandlerA(EntityA ea, TaskEntityA tea)
        {
            _entityA = ea;
            _taskEntityA = tea;
        }
    }
    public class EntityHandlerB
    {
        private readonly EntityB _entityB;
        private readonly TaskEntityB _taskEntityB;
        public EntityHandlerA(EntityB eb, TaskEntityB teb)
        {
            _entityB = ea;
            _taskEntityB = teb;
        }
    }
