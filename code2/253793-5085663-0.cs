    foreach(var i in singleProperties)
    {
      var reference = value.GetType().GetProperty(i.Name + "Reference");
      var refValue = reference.GetValue(value, null);
      var isLoaded = ((System.Data.Objects.DataClasses.EntityReference)(refValue)).IsLoaded;
      if(isLoaded)
      {
      }
    }
