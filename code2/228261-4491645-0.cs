    interface IBehavior
    {
      // Binds whatever events this behaviour needs, and optionally adds
      // itself to a collection of behaviours on the entity.
      void Register(Entity e);
    }
    // Just an example
    public abstract class TurnEndingDoSomethingBehavior
    {
      public void Register(Entity e)
      {
        e.TurnEnding += (s, e) => DoSomething();
      }
      private abstract void DoSomething();
    }
