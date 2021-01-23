    public interface IChargable
    {
        void StartCharging();
    }
    
    public interface IWeapon
    {
        void Fire();
    }
    
    public class Weapon : IWeapon
    {
        public void Fire()
        { } 
    }
    
    public class ChargedWeapon : Weapon, IChargable
    {
        public void StartCharging ()
        { }
    }
    private Weapon weapon;
    public void HandleUserInput()
    {
        if (MouseButton.WasPressed() && weapon is IChargable)
        {
            ((IChargable)weapon).StartCharging();
        }
        else if (MouseButton.WasReleased())
        {
            weapon.Fire();
        }
    }
