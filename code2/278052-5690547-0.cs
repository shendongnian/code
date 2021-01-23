    pubilc interface IMovementLogic<T> where T:Entity
    {
         T Apply(Position p); 
        //You can name the method anything else you like such as "Move" or "execute
    }
    public class EntityMovement : IMovementLogic<Entity> {...}
    public class CombatantMovement : IMovementLogic<Combatant> {...}
    public class AvatarMovement : IMovementLogic<Avatar> {...}
