public abstract class BaseClass
{   
    protected BaseClass()
    {
        // original code
        // someEvent += OnChange;
        someEvent += OnChangeBase;      
    }
    private void OnChangeBase(bool foo)
    {
        var policy = GetRetryPolicy();
        policy.Execute(() => OnChange(foo));
    }
    protected abstract void OnChange(bool param);
}
