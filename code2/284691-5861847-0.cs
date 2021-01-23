    public interface IWeapon
    {
        void Strike();
    }
    
    public class Sword : IWeapon
    {
        public void Strike()
        {
            Console.WriteLine("black ninja strike");
        }
    }
    
    public class Ninja
    {
        private readonly IWeapon _weapon;
        public Ninja(IWeapon weapon)
        {
            _weapon = weapon;
        }
    
        public void Strike()
        {
            _weapon.Strike();
        }
    }
    
    public class WarriorModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWeapon>().To<Sword>();
        }
    }
    
    
    class Program
    {
        static void Main()
        {
            var kernel = new StandardKernel(new WarriorModule());
            var ninja = kernel.Get<Ninja>();
            ninja.Strike();
        }
    }
