    public class ShieldModifier : ScriptableObject, IDamageModifier
    {
        private float shieldAmount = 10;
    
        public float Apply(float damage)
        {
            var actualDamage = Mathf.Max(0, damage - this.shieldAmount)
    
            return actualDamage;
        }
    }
    
    public class InvulnerabilityModifier: ScriptableObject, IDamageModifier
    {
        public float Apply(float damage)
        {
            return 0;
        }
    }
