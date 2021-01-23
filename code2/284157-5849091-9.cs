    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        class A
    {
        public delegate void delegateB();
        public delegateB _B;
    
        public A() {
          _B = B;
        }
        public void Override(delegateB newB)
        {
            _B = newB;
        }
    
        public virtual void B()
        {
            if (_B != null && _B != this.B) {
                Console.WriteLine("OVERRIDEN B IN A");
                _B();
            }
            else {
            Console.WriteLine("VIRTUAL B IN A");
            }
        }
    }
    
        class cB : A {
            public override void B() {
                if (base._B != null && base._B != this.B)
                {
                    Console.WriteLine("OVERRIDEN B IN B");
                    _B();
                }
                else
                {
                    Console.WriteLine("IN B");
                }
                
            }
        }
    
    class Program
    {
        class Overrider {
           public void MyB()
           {
               Console.WriteLine("MyB");
           }
        }
    
        public static void Main(string[] Args)
        {
            A a = new A();
            a.B();
            Overrider ovr = new Overrider();
            a.Override(ovr.MyB);
            a.B(); // Will print MyB
            cB b = new cB();
            b.B();
            b.Override(ovr.MyB);
            b.B();
        }
    }
    }
