csharp
string Foo(Resource parameter = null)
{
    if (parameter == null)
    {
        using (var res = new Resource())
        {
            return Foo(res);   
        }
    }
    else 
    {
        parameter.Something();
        ...
        return ...;
    }
}
You'll only recurse once, so you don't need to worry about unbounded stacks etc.
