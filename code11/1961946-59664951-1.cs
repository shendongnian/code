csharp
public class ExampleService 
{
    private readonly IReminderStrategy strategy;
    
    public ExampleService(IReminderStrategy strategy)
    {
        this.strategy = strategy;
    }
}
The decision on which strategy type to provide should be delegated to the IoC container. Something like
csharp
if (useA)
{
    // bind IReminderStrategy to StrategyA
}
else
{
    // bind IReminderStrategy to StrategyB
} 
