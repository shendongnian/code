    public class ReflectDamageModifier: IDamageModifier
    {
        private float reflectionFactor = 0.5; // Reflect 50% of damage
        public float Apply(float damage, IHealth attacker)
        {
            attacker.TakeDamage(damage * this.reflectionFactor);
            return damage;
        }
    }
