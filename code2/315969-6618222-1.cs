    namespace ISelfTester
    {
        interface ISelf<out T> {T Self {get;} }
    
        interface IThis { void doThis(); }
        interface IThat { void doThat(); }
        interface IOther { void doOther(); }
    
        interface IThis<out T> : IThis, ISelf<T> {}
        interface IThat<out T> : IThat, ISelf<T> {}
        interface IOther<out T> : IOther, ISelf<T> {}
    
        class ThisOrThat : IThis<ThisOrThat>, IThat<ThisOrThat>
        {
            public ThisOrThat Self { get { return this; } }
            public void doThis() { Console.WriteLine("{0}.doThis", this.GetType()); }
            public void doThat() { Console.WriteLine("{0}.doThat", this.GetType()); }
        }
        class ThisOrOther : IThis<ThisOrOther>, IOther<ThisOrOther>
        {
            public ThisOrOther Self { get { return this; } }
            public void doThis() { Console.WriteLine("{0}.doThis", this.GetType()); }
            public void doOther() { Console.WriteLine("{0}.doOther", this.GetType()); }
        }
        class ThatOrOther : IThat<ThatOrOther>, IOther<ThatOrOther>
        {
            public ThatOrOther Self { get { return this; } }
            public void doThat() { Console.WriteLine("{0}.doThat", this.GetType()); }
            public void doOther() { Console.WriteLine("{0}.doOther", this.GetType()); }
        }
        class ThisThatOrOther : IThis<ThisThatOrOther>,IThat<ThisThatOrOther>, IOther<ThisThatOrOther>
        {
            public ThisThatOrOther Self { get { return this; } }
            public void doThis() { Console.WriteLine("{0}.doThis", this.GetType()); }
            public void doThat() { Console.WriteLine("{0}.doThat", this.GetType()); }
            public void doOther() { Console.WriteLine("{0}.doOther", this.GetType()); }
        }
        static class ISelfTest
        {
            static void TestThisOrThat(IThis<IThat> param)
            {
                param.doThis();
                param.Self.doThat();
            }
            static void TestThisOrOther(IThis<IOther> param)
            {
                param.doThis();
                param.Self.doOther();
            }
            static void TestThatOrOther(IThat<IOther> param)
            {
                param.doThat();
                param.Self.doOther();
            }
    
            public static void test()
            {
                IThis<IThat> ThisOrThat1 = new ThisOrThat();
                IThat<IThis> ThisOrThat2 = new ThisOrThat();
                IThis<IOther> ThisOrOther1 = new ThisOrOther();
                IOther<IThat> OtherOrThat1 = new ThatOrOther();
                IThis<IThat<IOther>> ThisThatOrOther1 = new ThisThatOrOther();
                IOther<IThat<IThis>> ThisThatOrOther2a = new ThisThatOrOther();
                var ThisThatOrOther2b = (IOther<IThis<IThat>>)ThisThatOrOther1;
                TestThisOrThat(ThisOrThat1);
                TestThisOrThat((IThis<IThat>)ThisOrThat2);
                TestThisOrThat((IThis<IThat>)ThisThatOrOther1);
                TestThisOrOther(ThisOrOther1);
                TestThisOrOther((IThis<IOther>)ThisThatOrOther1);
                TestThatOrOther((IThat<IOther>)OtherOrThat1);
                TestThatOrOther((IThat<IOther>)ThisThatOrOther1);
            }
        }
    }
