namespace ISelfTester
{
    interface ISelf&lt;out T&gt; {T Self {get;} }
    interface IThis { void doThis(); }
    interface IThat { void doThat(); }
    interface IOther { void doOther(); }
    interface IThis&lt;out T&gt; : IThis, ISelf&lt;T&gt; {}
    interface IThat&lt;out T&gt; : IThat, ISelf&lt;T&gt; {}
    interface IOther&lt;out T&gt; : IOther, ISelf&lt;T&gt; {}
    class ThisOrThat : IThis&lt;ThisOrThat&gt;, IThat&lt;ThisOrThat&gt;
    {
        public ThisOrThat Self { get { return this; } }
        public void doThis() { Console.WriteLine("{0}.doThis", this.GetType()); }
        public void doThat() { Console.WriteLine("{0}.doThat", this.GetType()); }
    }
    class ThisOrOther : IThis&lt;ThisOrOther&gt;, IOther&lt;ThisOrOther&gt;
    {
        public ThisOrOther Self { get { return this; } }
        public void doThis() { Console.WriteLine("{0}.doThis", this.GetType()); }
        public void doOther() { Console.WriteLine("{0}.doOther", this.GetType()); }
    }
    class ThatOrOther : IThat&lt;ThatOrOther&gt;, IOther&lt;ThatOrOther&gt;
    {
        public ThatOrOther Self { get { return this; } }
        public void doThat() { Console.WriteLine("{0}.doThat", this.GetType()); }
        public void doOther() { Console.WriteLine("{0}.doOther", this.GetType()); }
    }
    class ThisThatOrOther : IThis&lt;ThisThatOrOther&gt;,IThat&lt;ThisThatOrOther&gt;, IOther&lt;ThisThatOrOther&gt;
    {
        public ThisThatOrOther Self { get { return this; } }
        public void doThis() { Console.WriteLine("{0}.doThis", this.GetType()); }
        public void doThat() { Console.WriteLine("{0}.doThat", this.GetType()); }
        public void doOther() { Console.WriteLine("{0}.doOther", this.GetType()); }
    }
    static class ISelfTest
    {
        static void TestThisOrThat(IThis&lt;IThat&gt; param)
        {
            param.doThis();
            param.Self.doThat();
        }
        static void TestThisOrOther(IThis&lt;IOther&gt; param)
        {
            param.doThis();
            param.Self.doOther();
        }
        static void TestThatOrOther(IThat&lt;IOther&gt; param)
        {
            param.doThat();
            param.Self.doOther();
        }
        public static void test()
        {
            IThis&lt;IThat&gt; ThisOrThat1 = new ThisOrThat();
            IThat&lt;IThis&gt; ThisOrThat2 = new ThisOrThat();
            IThis&lt;IOther&gt; ThisOrOther1 = new ThisOrOther();
            IOther&lt;IThat&gt; OtherOrThat1 = new ThatOrOther();
            IThis&lt;IThat&lt;IOther&gt;&gt; ThisThatOrOther1 = new ThisThatOrOther();
            IOther&lt;IThat&lt;IThis&gt;&gt; ThisThatOrOther2a = new ThisThatOrOther();
            var ThisThatOrOther2b = (IOther&lt;IThis&lt;IThat&gt;&gt;)ThisThatOrOther1;
            TestThisOrThat(ThisOrThat1);
            TestThisOrThat((IThis&lt;IThat&gt;)ThisOrThat2);
            TestThisOrThat((IThis&lt;IThat&gt;)ThisThatOrOther1);
            TestThisOrOther(ThisOrOther1);
            TestThisOrOther((IThis&lt;IOther&gt;)ThisThatOrOther1);
            TestThatOrOther((IThat&lt;IOther&gt;)OtherOrThat1);
            TestThatOrOther((IThat&lt;IOther&gt;)ThisThatOrOther1);
        }
    }
}
