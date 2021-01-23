csharp
public TResult ParseSomething<TResult>(ParseContext context)
{
    if (typeof(TResult) == typeof(string))
    {
        var token = context.ParseNextToken();
        string parsedString = token.ParseToDotnetString();
        return Unsafe.As<string, TResult>(ref parsedString);
    }
    else if (typeof(TResult) == typeof(int))
    {
        var token = context.ParseNextToken();
        int parsedInt32 = token.ParseToDotnetInt32();
        // This will not box which might be critical to performance
        return Unsafe.As<int, TResult>(ref parsedInt32); 
    }
    // other cases omitted for brevity's sake
}
`Unsafe.As` will be replaced by the JIT with efficient machine code instructions, as you can see in the official CoreFX repo:
[![Source Code of Unsafe.As][1]][1]
  [1]: https://i.stack.imgur.com/3oulF.png
