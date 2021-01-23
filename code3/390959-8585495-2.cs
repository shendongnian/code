    Bind<IWeapon>().To<Shuriken>().Named("Strong");
    Bind<IWeapon>().To<Dagger>().Named("Weak"); 
...
    class WeakAttack {
        readonly IWeapon _weapon;
        public([Named("Weak")] IWeapon weakWeapon)
            _weapon = weakWeapon;
        }
        public void Attack(string victim){
            Console.WriteLine(_weapon.Hit(victim));
        }
    }
