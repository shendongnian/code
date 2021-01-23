        foreach (PropertyInfo item in info)
        {
            if (item.CanWrite)
            {
                 switch (item.Name)
                 {
                     case "ClientName"
                         // A property exists inside the control": //
                         item.SetValue(userControl, "john", null); 
                         // john is the new value here
                     break;
                 }
            }
        }
