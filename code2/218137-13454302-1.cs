    public void DoSwitch(Test val)
    {
       switch (val)
       {
           case (Test.TestValue1) : DoSomething();
                                    break;
           case (Test.TestValue2) : DoSomethingElse();
                                    break;
           default                : Do Nothing();
       }
    }
