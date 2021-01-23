    public void DoSomething(bool myBool)
    {
        var myBoolConverted = myBool ? 1 : 0;
        myDatabase.DoSomething(myBoolConverted);
    }
