    static void Test()
    {
      var instance = new Imple();
      instance.Choose(2);
      instance.Effect();
    }
    public interface choices
    {
      void Effect();
    }
    public class Imple : choices
    {
      private Action SelectedEffect;
      public void Effect()
      {
        if ( SelectedEffect != null ) SelectedEffect();
      }
      private void Effect1()
      {
        Console.WriteLine("Effect1 called.");
      }
      private void Effect2()
      {
        Console.WriteLine("Effect2 called.");
      }
      public void Choose(int index)
      {
        switch ( index )
        {
          case 1:
            SelectedEffect = Effect1;
            break;
          case 2:
            SelectedEffect = Effect2;
            break;
          default:
            throw new NotImplementedException("Effect version n°" + index);
        }
      }
    }
