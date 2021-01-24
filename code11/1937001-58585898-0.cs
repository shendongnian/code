class TestHelpers
{
    public static void AssertReflexivity<X>(X x)
    {
        bool isEqual = x.Equals(x);
        Assert.IsTrue("Add a good message here, otherwise test output may be hard to read");
    }
    public static AssertSymmetry<X,Y>(X x, Y y)
    {
        bool xy = x.Equals(y);
        bool yx = y.Equals(x);
        Assert.AreEqual(xy, yx, "Add a good message here, otherwise test output may be hard to read" );
    }
...
[Test]
public void Test1() {
   var x = new SomeType1()
   AssertReflexivity(x);
}
[Test]
public void Test2() {
   var x = new SomeType1();
   var y = new SomeType2();
   AssertReflexivity(x, y);
}
----
# Few points
## If this is about the same type 
1. You could use one type in your class 
class TestHelpers
{
    public static void AssertReflexivity<T>(T x)
    {
        bool isEqual = x.Equals(x);
        Assert.IsTrue("Add a good message here, otherwise test output may be hard to read");
    }
    public static AssertSymmetry<T>(T x, T y)
2. What if you compare two objects that have all their properties set to null? Are they reflexive?
## If this his about different types 
 
* It hangs on how `Equals` is overridden/implemented - these tests could pass/fail in many different scenarios that don't have much to do with the relationships between types, but just the data setup.
* Should different types by reflexive? 
* What if you compare two objects that have all their properties set to null? Are they reflexive?
