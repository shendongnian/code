    public abstract class CommandType<TCommand> : InputObjectType<TCommand> 
        where TCommand : Command {
      protected override void Configure(IInputObjectTypeDescriptor<TCommand> desc) {
        desc.Field(f => f.CausationId).Ignore();
        desc.Field(f => f.CorrelationId).Ignore();
      }
    }
