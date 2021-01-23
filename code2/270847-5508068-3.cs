    public static object GetPropertyValue(this object car, string propertyName)
    {
       return car.GetType().GetProperties()
          .Single(pi => pi.Name == propertyName)
          .GetValue(car, null);
    }
