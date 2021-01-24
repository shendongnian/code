csharp
public interface ICensoreable<T>
{
    sealed ICensoreable<T> GetCensored()
    {
        var result = Clone();
        result.CensorInformation();
        return result;
    }
    ICensoreable<T> Clone();
    void CensorInformation();
}
public class User : ICensoreable<User>
{
    public User(User other)
    {
        name = other.name;
        password = other.password;
    }
    public string name;
    public string password;
    public void CensorInformation()
    {
        password = null;
    }
    public User Clone() => new User(this);
    ICensoreable<User> ICensoreable<User>.Clone() => Clone();
}
Using the `GetCensored()` method:
csharp
var user = new User();
var censored = ((ICensoreable<User>)user).GetCensored();
**NOTE:** As of the time of writing, this implementation **will** throw a `NullReferenceException` at the first line of the `GetCensored()` method (using C# 8.0 on VS 16.4.0 Preview 2.0). I personally assume this is a bug, since removing the `sealed` keyword will not cause any issues whatsoever with the exact same code. Furthermore, I tried another implementation which involved initializing a new object of type `T`, which also crashed. The line was `var result = new T();` and it threw a `NullReferenceException`.
Theoretically, and as per the proposal, the `sealed` keyword simply prevents types from overriding the interface method and only keeping the default implementation.
