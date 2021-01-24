    public class TestA : IDataAdapter<A>{}
    public class TestB : IDataAdapter<B>{}
    public class TestC : IDataAdapter<C>{}
    public class TestIFoo : IDataAdapter<IFoo>{}
    public class TestIBar : IDataAdapter<IBar>{}
    public class TestIBoth : IDataAdapter<IFoo>,IDataAdapter<IBar>{}
