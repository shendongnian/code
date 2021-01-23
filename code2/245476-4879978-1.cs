    public static void GetMyProperties(object obj)
    {
      foreach (PropertyInfo pinfo in obj.GetType().GetProperties())
      {
        var getMethod = pinfo.GetGetMethod();
        if (getMethod.ReturnType.IsArray)
        {
          var arrayObject = getMethod.Invoke(obj, null);
          foreach (object element in (Array) arrayObject)
          {
            foreach (PropertyInfo arrayObjPinfo in element.GetType().GetProperties())
            {
              Console.WriteLine(arrayObjPinfo.Name + ":" + arrayObjPinfo.GetGetMethod().Invoke(element, null).ToString());
            }
          }
        }
      }
    }
