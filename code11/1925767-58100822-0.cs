void someFunction(Base bObj)
{
    // bObj.Derived1Method() if bObj is Derived1
    // or
    // bObj.Derived2Method() if bObj is Derived2
}
you are in trouble.
There are two ways. Either you use pattern matching:
switch (bObj)
{
    case Derived1 d1:
        d1.Derived1Method();
        break;
    case Derived2 d2:
        d1.Derived2Method();
        break;
}
Advantages: statically typed, type-safe.  
Disadvantages: violation of the Open-Closed principle of SOLID.
Or you go `dynamic` and use double dispatch:
void someFunction(Base bObj)
{
    dynamic d = (dynamic)bObj;
    DoSomething(d);
}
void DoSomething(Derived1 d1) => d1.Derived1Method();
void DoSomething(Derived2 d2) => d2.Derived2Method();
Advantages: ???  
Disadvantages: slow, not type safe, can throw at runtime.
