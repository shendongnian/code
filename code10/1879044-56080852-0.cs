 c#
public class MyType : BaseModel
{
    private string _name;
    public string Name {
        get => _name;
        set => SetProperty(ref _name, value);
    }
    private int _id;
    public string Id {
        get => _id;
        set => SetProperty(ref _id, value);
    }
}
I'm guessing the Tomtom version is trying to avoid having to declare the fields, i.e.
 c#
public class MyType : BaseModel
{
    public string Name {
        get => GetProperty<string>();
        set => SetProperty<string>(value);
    }
    public string Id {
        get => Get<int>();
        set => SetProperty<int>(value);
    }
}
But... yeah, don't do that. In addition to everything else, this ends up boxing all the value-types. Fields are fine...
