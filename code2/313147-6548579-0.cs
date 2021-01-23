    public void CreateMeter(int UserChoice)
    {
        Meter MyMeter = new Meter();
        MyMeter.FooGuid = Manager.Foos[UserChoice].TheGuid;
    }
