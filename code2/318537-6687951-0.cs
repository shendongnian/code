    class A
        {
            public virtual void foo()
            {
                MessageBox.Show("A");
            }
        }
    
        class B : A
        {
            public override void foo()
            {
                MessageBox.Show("B");
                base.foo();
            }
        }
    
        class C : B
        {
            public override void foo()
            {
                MessageBox.Show("C");
                base.foo();
            }
        }
    C c = new C();
    c.foo();
