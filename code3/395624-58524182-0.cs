cs
class BaseClass
{
    protected BaseClass()
    {
        Log = LogManager.GetLogger(GetType().ToString());
    }
    protected Logger Log { get; private set; }
}
class ExactClass : BaseClass
{
    public ExactClass() : base() { }
    ...
}
