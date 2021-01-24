 c#
static class MyClass {
    static public event EventHandler MyEvent;
}
class MyClass<T> {
    // ...
}
Note that static events are often, but not always, a bad design choice.
