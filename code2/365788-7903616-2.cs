    public void higherLevelFunction()
    {
        using(NpgsqlDataReader result = myThingDoer.DoQuery())
          result.Read();
    }
