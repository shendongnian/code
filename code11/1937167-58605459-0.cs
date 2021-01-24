cs
delegate void GenericDelegate<T>(T t);
static void GenericMethod<T>(GenericDelegate<T> method) { }
static void Method(int _) { }
static void Method(float _) { }
static void CallingMethod()
{
    GenericMethod(Method);
}
When method group `Method` has two overloads, the compiler can't infer the type of `T`. The issue is actually exactly the same even if that method group only contains one overload!
Now, to answer my other question, can the calling code be as simple as described above? Well, not without major restructuring. Something like this works for me, though:
cs
static void GenericMethod<T>(IMethod<T> method) { }
interface IMethod<T>
{
    void Method(T _);
}
class IntMethod: IMethod<int>
{
    public void Method(int _) { }
}
static void CallingMethod()
{
    GenericMethod(new IntMethod());
}
I'll admit, it's vastly different from the code example above, but achieves what I was aiming for: A clean calling site. This solution comes at the cost of a slightly messier declaration. Whether this is a win or loss in readability and usage is highly dependent on the use-case.
  [1]: https://stackoverflow.com/a/58599762
