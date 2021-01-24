public interface ICommandService<TCommand>
{
   Task Execute(TCommand command);
}
public class LoggingCommandService<TCommand> : ICommandService<TCommand>
{
  public LoggingCommandService(ICommandService<TCommand> command, ILogger logger)
  {
    ...
  }
  public async Task Execute(TCommand command)
  {
    // log
    await this.command.Execute(command);
    // log
  }
}
