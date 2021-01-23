    class A:B
    {
        protected override void Method(BaseClass bc)
        {
            ((DerivedClass)bc).DerivedClassField = blabla;
        }
    }
