    public static GetAppointsFromDB(params)
    {
      var MyQuery = from....where...
                    select new MyModel{
                    AppointDate = ...,
                    TotalAppoints = ...,
                    AppointDuration =...};
      return MyQuery as MyModel;
    }
