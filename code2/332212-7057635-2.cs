    public interface ICreature { ... }
    public class Creature : ICreature
    {
        ... 
        public void Attack(ICreature creature)
        {
            DealDamage(creature, 3); // Hard-coded 3 to simplify example only
        }
        public virtual void DealDamage(ICreature target, int damage) { ... }
    }
    .... Test ....
    var wrappedAttacker = new Mock<Creature>();
    var mockTarget = new Mock<ICreature>();
            
    wrappedAttacker.Object.Attack(mockTarget.Object);
    wrappedAttacker.Verify(x => x.DealDamage(mockTarget.Object, 3), Times.Once());
