python
class A(object):
    def Confirm(self):
        print("A")
class B(A):
    def Confirm(self):
        print("B.Confirm ENTER")
        super().Confirm() # E forces that it will call C.Confirm()
        print("B.Confirm EXIT")
class C(A):
    def Confirm(self):
        print("C.Confirm ENTER")
        super().Confirm() # E forces that it will call D.Confirm()
        print("C.Confirm EXIT")
class D(A):
    def Confirm(self):
        print("D.Confirm ENTER")
        super().Confirm()
        print("D.Confirm EXIT")
class E(B,C,D):
    pass
e = E()
e.Confirm()
and here a C# code with the same output
c#
using System;
					
public class Program
{
	public static void Main()
	{
		var e = new E();
		e.Confirm();
	}
}
class A
{
	public virtual void Confirm()
	{
		Console.WriteLine("A");
	}
}
class B : C
{
	public override void Confirm()
	{
		Console.WriteLine("B.Confirm ENTER");
		base.Confirm();
		Console.WriteLine("B.Confirm EXIT");
	}
}
class C : D
{
	public override void Confirm()
	{
		Console.WriteLine("C.Confirm ENTER");
		base.Confirm();
		Console.WriteLine("C.Confirm EXIT");
	}
}
class D : A
{
	public override void Confirm()
	{
		Console.WriteLine("D.Confirm ENTER");
		base.Confirm();
		Console.WriteLine("D.Confirm EXIT");
	}
}
class E : B
{
}
live view at [.net fiddle](https://dotnetfiddle.net/8iUcPz)
output of both codes
B.Confirm ENTER
C.Confirm ENTER
D.Confirm ENTER
A
D.Confirm EXIT
C.Confirm EXIT
B.Confirm EXIT
