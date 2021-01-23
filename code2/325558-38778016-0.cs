    private readonly Lazy<string> lazyBar;
    public Foo()
    {
        lazyBar = new Lazy<string>(() => someExpression);
        Contract.Ensures(!lazyBar.IsValueCreated);
    }
        [ContractInvariantMethod]
        private static void Invariant()
        {
            Contract.Invariant(!lazyBar.IsValueCreated || lazyBar.Value != null);
        }
    public void DoSomething()
    {
        Contract.Assume(lazyBar.IsValueCreated);
        lazyBar.Value.AccessSomeMethod; //Here Code Contracts detect "Possibly calling a method on a null reference"
        ...
    }
}
