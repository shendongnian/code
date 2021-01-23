    abstract class Warning {
      public String Description { get; protected set; }
      public abstract IEnumerable<Consequence> Consequences { get; }
      public abstract IEnumerable<Action> Actions { get; }
    }
    class CompanyDeletionWarning : Warning {
      public override IEnumerable<Consequence> Consequences { get { ... } }
      public override IEnumerable<Action> Actions { get { ... } }
    }
