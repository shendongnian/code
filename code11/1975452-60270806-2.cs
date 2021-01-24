 c#
Decorator(SomeMethod); // not cached
Decorator(() => SomeMethod()); // cached
You can see the difference [here](https://sharplab.io/#v2:EYLgtghgzgLgpgJwD4AEBMBGAsAKF+gAgAUCBvfAFgIDkB7GAYQgGMALOAEwAoBKM3AoIAicZrQQQY4rgGVaYOAFk4MVrQ48A3LgC+lAkzade/HIIIixEqQi4mAvAD4CchctXreW3bn2XxktIoGGgEEHykYbyaBHo4wQBsBChUrkoqatwRsbpAA=)
This is because the difference is detectable (different object refs vs same object ref) and could *in theory* lead to different program behavior in existing code that used the original (non-lambda) syntax; so the cache provision has not to-date been applied retrospectively to the old syntax. Compatibility reasons. This has been discussed for years, though; IMO it is one of those things like the change to `foreach` L-value captures, that could probably be changed without breaking the world as much as we imagine.
---
To see the theoretical difference in an example based on the edited question:
 c#
using System;
class A
{
    static void Main()
    {
        var obj = new A();
        Console.WriteLine("With cache...");
        for (int i = 0; i < 5; i++) obj.WithCache();
        Console.WriteLine("And without cache...");
        for (int i = 0; i < 5; i++) obj.WithoutCache();
    }
    Action _m2;
    B b = new B();
    public void WithCache() => b.Decorate(_m2 ??= M2);
    public void WithoutCache() => b.Decorate(M2);
    public void M2() => Console.WriteLine("I'm M2");
}
 class B
{
    private object _last;
    public void Decorate(Action a)
    {
        if (_last != (object)a)
        {
            a();
            _last = a;
        }
        else
        {
            Console.WriteLine("No do-overs!");
        }
    }
}
This currently outputs:
 txt
With cache...
I'm M2
No do-overs!
No do-overs!
No do-overs!
No do-overs!
And without cache...
I'm M2
I'm M2
I'm M2
I'm M2
I'm M2
