public Interface IAction {
    void DoSomething();
    int DoSomethingElse();
}
Now, all actions have some standard things they do and diff in others
public abstract AbstractAction: IAction {
    public int Energy {get; private set;}
    public int Damage {get; private set;}
}
Now create different classes for each action
public class PlayerTakeDamageAction: AbstractAction {
    public PlayerTakeDamageAction(/*some parameters*/) {
    }
    // Override the behavior per class
}
What does all this have to do with you? Now you can apply `IoC` by using Dependency Injection or the FactoryPattern. That means that you delegate the creation of the `IAction` object to someone else.
