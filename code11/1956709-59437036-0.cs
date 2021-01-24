internal interface IParser
{
... // if you can define any. or it can be empty also
}
public interface IParser<T1, T2> : IParser
{
   ...
}
And change your method signature to this :
public void SomeMethod<TParser> () where TParser : IParser new() 
{
   ...
}
