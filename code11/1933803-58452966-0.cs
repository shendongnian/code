c#
private async Task ExecuteSequential()
{
    List<Action> sequentialMethods = new List<Action>()
    {
        SomeMethod1,
        SomeMethod2,
        ExecuteParallel,
        SomeMethod3,
        SomeMethod4
    };
    for ( int i = 0 ; i < sequentialMethods.Count ; i++ )
    {
        sequentialMethods.ElementAt( i ).Invoke();
    }
}
private void ExecuteParallel()
{
    List<Action> methods = new List<Action>()
    {
        MyMethod1,
        MyMethod2,
        MyMethod3
    };
    Parallel.ForEach( methods , ( currentMethod ) => currentMethod.Invoke() );            
}
