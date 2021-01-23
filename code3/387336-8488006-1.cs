    class Program {
      public static void Main() {
        using(IKernel kernel = new StandardKernel(new WeaponsModule()))
        {
          var samurai = kernel.Get<Samurai>();
          warrior1.Attack("the evildoers");
        }
      }
    }
    public class WarriorModule : NinjectModule {
      public override void Load() {
        Bind<IWeapon>().To<Sword>();
        Bind<Samurai>().ToSelf().InSingletonScope();
      }
    }
