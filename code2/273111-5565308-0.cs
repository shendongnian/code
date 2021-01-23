    public void DoStuff<T>(MyGeneric<T> objA, MyGeneric<T> objB) 
        where T : struct, IComparable, IConvertible
    {
        if (objA.MyProperty.CompareTo(objB.MyProperty) > 0)
        {
            //do stuff
        }
    }
