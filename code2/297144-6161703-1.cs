    public class WeaponModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWeapon>().To<Sword>();
            // Optional, Ninject will try to resolve any non-registered concrete type.
            Bind<Samuari>().ToSelf();
        }
    }
