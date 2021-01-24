public void M()
{
    ((IB)this).M(); // Throws stack overflow
}
That's essentially 
public void M()
{
    M(); // Throws stack overflow
}
Default interface members are called the same way explicitly implemented interface methods are, through the interface. Besides, you're asking to call the method on `this`, not `base`.
