csharp
public class Foo1
{
    public int Id { get; set; }
    // .... More data
    public int foo2Id { get; set; } // Foo2 identfier only, not a Foo2 instance
}
public class Foo2
{
    public int Id { get; set; }
    public int Type { get; set; }
}
If modification of `Foo1` necessitates same for `Foo2`, that must be done by retrieving `Foo2` by its identifier that is held by `Foo1`, as the following example shows. Note that for simplicity the example modifies both aggregate roots in the same transaction; this kind of modification, however, usually happen in separate transactions and are _eventually consistent_.
csharp
Foo1 foo1 = foo1Repository.findById(foo1Id);
// modify foo1 state
Foo2 foo2 = foo2Repository.findById(foo1.foo1Id);
// modify foo2 state
// persist changes
foo1Repository.store(foo1);
foo2Repository.store(foo2);
