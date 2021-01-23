    public void DoStuff(MyBaseClass objA, MyBaseClass objB) 
    {
        if (objA.GetType().IsGenericType && 
            objA.GetGenericTypeDefinition() == typeof(MyGeneric<>) &&
            objA.GetType() == objB.GetType()
           )
        {
            dynamic objADyn = objA;
            dynamic objBDyn = objB;
            if (objADyn.MyProperty.CompareTo(objBDyn.MyProperty) > 0)
            {
                //do stuff
            }
        }
    }
