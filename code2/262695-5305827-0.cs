    List<Bar> LoadData(IBarFactory Factory)
    {
        List<Bar> MyList = new List<Bar>();
        if (Factory == null)
        {
            MyList.Add(new Bar());
        }
        else
        {
            MyList.Add(Factory.Create());
        }
        // etc, etc
    }
