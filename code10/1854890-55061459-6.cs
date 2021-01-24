    public class Enemy : MonoBehaviour, IHealth
    {
        public float Health {get; private set;}
        public List<IDamageModifier> modifiers; // Pretend this has both modifiers above.
    
        public void TakeDamage(float damage)
        {
            var actualDamage = damage;
    
            foreach(var mod in this.modifiers)
            {
                actualDamage = mod.Apply(actualDamage);
            }
    
            this.Health -= actualDamage; // 0 because of Invulnerability
        }
    }
