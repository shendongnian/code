public void processLambda(Action baseMethod) {
    readWriteLock.acquireWriteLock(-1);
    try {
        baseMethod.Invoke();
    } finally {
        readWriteLock.releaseWriteLock();
    }
}
public void Main()
{
   processLambda(parameterlessMethod);
   processLambda(() => methodWithParameters(param1, param2, ...)); 
}
