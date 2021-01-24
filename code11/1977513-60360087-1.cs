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
Here is a trivial example of an abstract factory
public class ActionConsumer {
    private IActionFactory factory;
    public A(IActionFactory factory) {
        this.factory = factory;
    }
    public void DoSomething() {
        IAction a = factory.MakeAction(Trigger.PlayerTakeDamageAction);
        a.DoSomething();
    }
}
public ConcreteActionFactory: IActionFactory {
    IAction MakeAction() {
        return new PlayerTakeDamageAction();
    }
    IAction MakeAction(Trigger trigger) {
        if (Trigger == Trigger.PlayerTakeDamageAction)
           return new PlayerTakeDamageAction();
        else if // you get the idea
    }
}
interface IActionFactory {
    // Creates some default action
    IAction MakeAction();
    // Creates some specific action
    // You can pass any parameters or create multiple action
    // generators, depending on what the new object needs.
    IAction MakeAction(Trigger trigger);
}
