    public class MyAction{
    public virtual void Invoke(SomeClass @this)
    {
        ldarg.1
        dup
        ldvirtftn SomeClass.GenericMethod<Int32>
        calli void *(argument)
        ret
    }
