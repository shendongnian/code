`
public sealed class UpdateFooModel
{
    private int? _maxFoo;
    public int? MaxFoo
    {
        get
        {
            return _maxFoo;
        }
        set
        {
            _maxFoo = (value == null) ? Int32.MaxValue : value;
        }
    }
    private int? _maxBar;
    public int? MaxBar
    {
        get
        {
            return _maxBar;
        }
        set
        {
            _maxBar = (value == null) ? Int32.MaxValue : value;
        }
    }
}
`
