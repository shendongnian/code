     arrayList arr = new arrayList();    
     foreach (ServiceController scTemp in scServices)
            {
                if (scTemp.Status == ServiceControllerStatus.Running)
                {
                    arr.add(scTemp.ServiceName);
                }
            }
      if(arr.contains("YourWantedName")
      {
      // loop again
      }
      else
      {
      // send mail
      }
