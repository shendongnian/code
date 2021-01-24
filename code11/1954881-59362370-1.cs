csharp
static void Main(string[] args)
{
   SomeClass sc = new SomeClass() { Field = new Random().Next() };
   sc.DoSomethingElse();
}
class SomeClass
{
   public int Field;
   public void DoSomethingElse()
   {
      Console.WriteLine(this.Field.ToString());
      // LINE 2: further code, possibly triggering GC
      Console.WriteLine("Am I dead?");
   }
   ~SomeClass()
   {
      Console.WriteLine("Killing...");
   }
}
that  may print:
615323
Killing...
Am I dead?
This is because of ***inlining*** and ***Eager Root Collection technique*** - `DoSomethingElse` method do not use any `SomeClass` fields, so `SomeClass` instance is no longer needed after `LINE 2`.
This happens to code in your constructor. After `// ... Pass it to unmanaged library` line your `Demo` instance becomes unreachable, thus its field `myDelWithMethod`. This answers the first question.
The case of empty lamba expression is different because in such case this lambda is cached in a static field, always reachable:
csharp
public class Demo
{
    [Serializable]
    [CompilerGenerated]
    private sealed class <>c
    {
        public static readonly <>c <>9 = new <>c();
        public static Action <>9__1_0;
        internal void <.ctor>b__1_0()
        {
        }
    }
    public Action myDelWithMethod;
    public Demo()
    {
        myDelWithMethod = (<>c.<>9__1_0 ?? (<>c.<>9__1_0 = new Action(<>c.<>9.<.ctor>b__1_0)));
    }
}
Regarding recommended ways in such scenarios, you need to make sure `Demo` has lifetime long enough to cover all unmanaged code execution. This really depends on your code architecture. You may make `Demo` static, or use it in a controlled scope related to the unmanaged code scope. It really depends.
