    public abstract class Command {
      protected Command(Guid? correlationId = null, Guid? causationId = null) {
        this.CausationId = this.CorrelationId = Guid.NewGuid();
      }
      public Guid CausationId { get; set; }
      public Guid CorrelationId { get; set; }
    }
