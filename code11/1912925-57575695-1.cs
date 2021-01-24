    // Highest level
    public abstract class Entity { }
    public abstract class TaskEntity { } 
    // Second level of abstractions for entities of type A and B
    public abstract class BaseEntityA : Entity { }
    public abstract class BaseEntityB : Entity { }
    public abstract class BaseTaskEntityA : TaskEntity { }
    public abstract class BaseTaskEntityB : TaskEntity { }
    // horizontal association of base entites
    public class BaseHandlerA<BaseEntityA, BaseTaskEntityA> { }
    public class BaseHandlerB<BaseEntityB, BaseTaskEntityB> { }
    // implementation of abstractions
    public class EntityA : BaseEntityA { }
    public class EntityB : BaseEntityB { }
    public class TaskEntityA : BaseTaskEntityA { }
    public class TaskEntityA : BasTaskEntityB { }
