    public MyCustomObject MethodBase(MyCustomObject myObj) 
    { 
        myObj.Name="FixedName";
        myObj.Surname="FixedSurname";
        myObj.Type = Types.Human;
        return myObj;
    } 
 
    public MyCustomObject SetOld(MyCustomObject  myObj) 
    { 
        MethodBase(); 
        myObj.IsOld = True;
        return myObj;
    } 
 
    public MyCustomObject SetYoung(MyCustomObject myObj) 
    { 
        MethodBase(); 
        myObj.IsOld = False;
        return myObj;
    } 
 
    public MyCustomObject SetIsDead(MyCustomObject myObj) 
    { 
        MethodBase(); 
        myObj.IsDead = True;
        return myObj;
    } 
    public void MainMethod(enum OperationType)
    {
        MyCustomObject myObj = new MyCustomObject();
        switch(OperationType)
        {
            case OperationTypes.Old:
                myObj = SetOld(myObj);
                break;
            case OperationTypes.Young:
                myObj = SetYoung(myObj);
                break;
            case OperationTypes.Dead:
                myObj = SetDead(myObj);
                break;
        }
    }
