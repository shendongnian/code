    namespace Foo
    {
       class Bar {}
    }
    namespace Baz
    {
       class Bar {}
    }
    Foo.Bar x = new Foo.Bar();
    Baz.Bar y = (Baz.Bar)x;
