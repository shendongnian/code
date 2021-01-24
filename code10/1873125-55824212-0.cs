csharp
private string _lastName;
public string LastName
{
    get => _lastName;
    set
    {
        _lastName= value.TrimAndReduce();
    }
}
