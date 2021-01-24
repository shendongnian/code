public class MyGeneric<T>
{
    public void Foo1(){}
}
which handles all 'global' functions, and then create a child class like this: 
public class MyGenericChild<T> : MyGeneric<T> where T : IMyInterface
{
    public void Foo2(){}
}
You can then use the specific child to handle the type specific methods.
If needed, you could expand this with a factory-pattern to retreive the correct generic class.
