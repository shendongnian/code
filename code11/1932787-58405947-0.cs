c#
public class Wrapper<T>
{
    public T Value;
    public static implicit operator T(Wrapper<T> wrapper) => wrapper.Value;
    public static implicit operator Wrapper<T>(T value) => new Wrapper<T> { Value = value };
}
Then try these:
c#
Wrapper<int> w1 = new Wrapper<int> { Value = 4 };
Wrapper<long> w2 = new Wrapper<long> { Value = 4 };
Assert.Equal(4, w1);        // error
Assert.Equal((short)4, w1); // no error
Assert.Equal(4, w2);        // no error
Assert.Equal(4l, w2);       // error
The only thing that makes `int` special is that that's the default type for the numeric literal. Otherwise, a type that wraps `int` works exactly the same as a type that wraps anything else. As long as a conversion is available only in one direction between the two parameters, everything's fine. But when the conversion is available in both directions, the compiler has no choice but to throw up its hands and give up.
