public abstract class BaseVarDef<T>
{
    public string DeveloperDescription = "";
    public T Value;
    public void SetValue(T value)
    {
        Value = value;
    }
    public void SetValue(BaseVarDef<T> value)
    {
        Value = value.Value;
    }
    public void ApplyChange(T amount)
    {
        AddValue(amount);
    }
    public void ApplyChange(BaseVarDef<T> amount)
    {
        AddValue(amount.Value);
    }
    protected abstract void AddValue(T val);
}
public class FloatVar : BaseVarDef<float>
{
    protected override void AddValue(float val)
    {
        Value += val;
    }
}
