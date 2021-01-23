    public class NinjaModule : NinjectModule {
        public void Load() {
           Bind<Samurai>().ToSelf()
           Bind<IWeapon>().To<Sword>();
        }
    } 
