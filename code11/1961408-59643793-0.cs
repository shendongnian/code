public class ProcessorA<TModel> : ProcessorBase where TModel : ModelBase, ISupportProcessA
{
    private readonly ISupportProcessA model;
    public ProcessorA(TModel model) : base(model)
    {
        this.model = model;
    }
    // ...some specific methods
}
This is a bit ugly however, as you need to create a new `ProcessorA<ModelDerived>`, rather than just a `ProcessorA`.
---------
You can add more boilerplate to make things a bit nicer:
public abstract class ProcessorBase
{
    protected abstract ModelBase ModelForBase { get; }
    // ...some shared methods
}
public abstract class ProcessorA : ProcessorBase
{
    public static ProcessorA Create<TModel>(TModel model) where TModel : ModelBase, ISupportProcessA
    {
        return new ProcessorA<TModel>(model);
    }
    // Abstract specific methods
    public abstract void SomeSpecificMethod();
}
public class ProcessorA<TModel> : ProcessorA where TModel : ModelBase, ISupportProcessA
{
    protected override ModelBase ModelForBase => model;
    private readonly TModel model;
    public ProcessorA(TModel model)
    {
        this.model = model;
    }
    // Specific method overrides
    public override void SomeSpecificMethod()
    {
    }
}
This means you can do `ProcessorA processor = ProcessorA.Create(new Model())`, but at the cost of a lot more boilerplate.
