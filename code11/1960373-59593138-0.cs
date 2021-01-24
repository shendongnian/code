public abstract class MyDatabase {
    /// <summary>
    /// A long detailed description about this method
    /// <summary>
    public abstract void RunSomething();
    /// <inheritdoc cref="MyDatabase.RunSomething"/>
    public abstract Task RunSomethingAsync();
}
Your last two method can inherit xml documentation from the first:
