    public static void GetMyProperties(object obj)
    {
      foreach (PropertyInfo pinfo in obj.GetType().GetProperties())
      {
        var getMethod = pinfo.GetGetMethod(); //getter
        if (getMethod.ReturnType.IsArray) // if array
        {
          var arrayObject = getMethod.Invoke(obj, null); // creating this array
          // casting each object in array to DeptArray
          foreach (DeptArray element in (Array) arrayObject)
          {
            
            Console.WriteLine("code:" + element.code + ", value: " + element.value);
          }
        }
      }
    }
