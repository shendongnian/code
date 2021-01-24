csharp
public long Method()
{
    int value = 10;
    return value;
}
This is just equivalent to:
csharp
public long Method()
{
    int value = 10;
    long valueToReturn = value;
    return valueToReturn;
}
So if you'd expect the second one to work, just think of the first as doing exactly that.
