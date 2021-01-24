using System;
public class A {
    public void Run() {
        Console.WriteLine("Foobar");
    }
}
Is completely equivalent in its effects, both in the CIL emitted as well as how users of `A` will use the class or derive it, to this code:
public class A {
    public void Run() {
        System.Console.WriteLine("Foobar");
    }
}
The same is true of C++, _except_ that you can define type aliases in a class that are visible to users of the class and _can_ be inherited.  However, these are not "namespaces."
class a {
public:
    using something_t = something_else;
};
class b : public a { };
Now `a::something_t` and `b::something_t` can be used to refer to the same type as `something_else`.
