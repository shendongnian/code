public class A<T>
{
    T DoStuff(T input)
    {
        return input;
    }
}
Accepts any struct or value type, including null types. The following line doesn't generate any warnings :
    var x=new A<string?>();
You have to specify that you want non-nullable types with the `notnull` constraint :
public class A<T>
    where T:notnull
{
    T DoStuff(T input)
    {
        return input;
    }
}
Using `string?` as a type parameter creates a warning now:
> warning CS8714: The type 'string?' cannot be used as type parameter 'T' in the generic type or method 'A<T>'. Nullability of type argument 'string?' doesn't match 'notnull' constraint.
All this is explained in [Try out Nullable Reference Types](https://devblogs.microsoft.com/dotnet/try-out-nullable-reference-types/).
To use *nullable* types you have to specify whether the type is a class or struct. The reason for this is explained in `The issue with T?` section of that blog post. `T?` implies that `T` is non-nullable so what is `T`? Class or Struct? The compiler handles each case differently. With a struct, the compiler will generate a `Nullable<T>` type while classes are handled by compiler magic. 
This code :
public class A<T>
{
    T? DoStuff(T input)
    {
        return input;
    }
}
Will throw a compiler error, not just a warning :
>  A nullable type parameter must be known to be a value type or non-nullable reference type. Consider adding a 'class', 'struct', or type constraint.
Adding the `class` constraint and passing `string` as the type parameter doesn't generate any errors or warnings :
public class A<T>
    where T:class
{
    T? DoStuff(T input)
    {
        return input;
    }
}
var x=new A<string>();
