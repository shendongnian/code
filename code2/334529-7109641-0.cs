    for (int i = 0; i < ReviewList.Count; i++)
    {
        string serviceCode = ReviewList[i].SERVICE.SERVICE_DESC;
        if(!serviceCode.Contains(".png")) { // once name set should not be modified
          if(serviceCode.Contains("*")) 
             ReviewList[i].SERVICE.SERVICE_DESC = "star" + serviceCode.Length + ".png";
          else
             ReviewList[i].SERVICE.SERVICE_DESC = "star0.png";
    
       }
    }
