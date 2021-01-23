            using System;
            class A
            {
              int _x;
              
              public A(int x)
              {
                _x = x;
              }
              public void Print(int y)
              {
                Console.WriteLine(_x + y);
              }
            }
            interface IPseudoDelegateVoidInt
            {
              void Call(int y);
            }
            class PseudoDelegateAPrint : IPseudoDelegateVoidInt
            {
              A _target;
              public PseudoDelegateAPrint(A target)
              {
                _target = target;
              }
              public void Call(int y)
              {
                _target.Print(y);
              }
            }
            class Program
            {
              delegate void RealVoidIntDelegate(int x);
              static void Main()
              {
                A a = new A(5);
                IPseudoDelegateVoidInt pdelegate = new PseudoDelegateAPrint(a);
                RealVoidIntDelegate rdelegate = new RealVoidIntDelegate(a.Print);
                pdelegate.Call(2);
                rdelegate(2);
              }
            }
