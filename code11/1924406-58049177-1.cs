csharp
public class A
{
  public virtual void Confirm()
  {
      Console.Writeline("A");
  }
}
public class B : A
{
  public virtual void Confirm()
  {
      base.Confirm();
      Console.Writeline("B");
  }
  protected void Confirm_Before1()
  {
  }
  protected void Confirm_After1()
  {
     Console.WriteLine("B");
  }
}
public class C : A
{
  public virtual void Confirm()
  {
      Console.Writeline("C");
      base.Confirm();      
  }
  protected void Confirm_Before1()
  {
      Console.Writeline("C");
  }
  protected void Confirm_After1()
  {
  }
}
public class D : A
{
  public virtual void Confirm()
  {
      Console.Writeline("D");
      base.Confirm();
      Console.Writeline("DD");      
  }
  protected void Confirm_Before1()
  {
      Console.Writeline("D");
  }
  protected void Confirm_After1()
  {
      Console.WriteLine("DD");
  }
}
public class E : A
{
  private readonly B _baseB = new B();
  private readonly C _baseC = new C();
  private readonly D _baseD = new D();
  public virtual void Confirm()
  {
    _baseB.Confirm_Before1();
    _baseC.Confirm_Before1();
    _baseD.Confirm_Before1();
    base.Confirm();
    _baseB.Confirm_After1();
    _baseC.Confirm_After1();
    _baseD.Confirm_After1();
  }
}
Your hypothetical compiler would have to parse the inheritance hierarchy, find all methods accessible from your multiply-inheriting type, split them into N+1 methods, where N is the number of `base` calls within them and call them all in order in your overloaded method.
Things get infintely more complicated if you change your example, however. What if `A` had an additional method `Foo`, `B.Confirm()` was:
public virtual void Confirm()
{
   base.Foo();
   Confirm.WriteLine("B");
}
and `C.Confirm()` was
public virtual void Confirm()
{
    Confirm.WriteLine("C");
    base.Foo();
}
What do you expect of `E.Confirm()`? Will it call `Foo` once or twice? And what if there were multiple calls to `Foo` in `B.Confirm()` but not in `C.Confirm()`? I have little idea on how Python handles this, it's enough to say that simply changing the `B` class to
class B(A):  
    def Confirm(self):
        super().Confirm()
        print("B")
        super().Confirm()
and calling `E.Confirm` results in 
C
D
A
DD
B
C
D
A
DD
That looks just baffling to me, which is a part of why MI is so hard.
Either way, the final answer is that if you want Python-esque behaviour, you'd have to implement a compiler that looks for multiple inheritance one way or another (most likely using an attribute) and transforms the code to do exactly what Python does. A concrete solution is way beyond an answer to an SO question, but if you run into any specific trouble implementing this crazy idea then feel free to ask another one.
EDIT:
As a PSA, I think that I should mention: if this is not just a fun exercise/thought experiment that you're doing, but rather you're trying to solve a real problem - this is not the way. Redesign your system to not rely on MI, or, if you're fond of the Python MI, don't use C#.
