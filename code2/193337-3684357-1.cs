    public string GetPage(string ipAddress){
      string result = dict["Default"];
       IPAddress ipAddress;
      if (IPAddress.TryParse(userHostIpAddress, out ipAddress))
      {
         string fullNameKey= ipAddress.Country();
         //Or you could use two letter code
         //string twoLetterKey = ipAddress.Iso3166TwoLetterCode();
           if(dict.ContainsKey(theKey)){
              result  = dict[fullNameKey];
           }
      }
      return result;
    }
 
 
