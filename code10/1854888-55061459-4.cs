    public interface IHealth
    {
        float Health {get};
        void TakeDamage(float damage);
    }
    public interface IDamageModifier
    {
       float Apply(float damage);
    }
