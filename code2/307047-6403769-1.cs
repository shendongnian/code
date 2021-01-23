            A a = new A();
            a.Code = "XXX";
            B b = new B();
            b.ShallowCopy(a);
            b.Start = DateTime.Now;
            B b2 = new B();
            b2.ShallowCopy(b);
