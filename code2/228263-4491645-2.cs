    interface IBehavior
    {
      // Binds whatever events this behaviour needs, and optionally adds
      // itself to a collection of behaviours on the entity.
      void Register(Entity entity);
    }
    // Just an example
    public abstract class TurnEndingDoSomethingBehavior
    {
      public void Register(Entity entity)
      {
        entity.TurnEnding += (s, e) => DoSomething();
      }
      private abstract void DoSomething();
    }
