            A a = new A();
            a.Code = "XXX";
            B b = new B();
            b.Copy(a);
            b.Start = DateTime.Now;
            B b2 = new B();
            b2.Copy(b);
