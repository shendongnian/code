    public string GetPage(string ipAddress){
      string result = null;
       IPAddress ipAddress;
      if (IPAddress.TryParse(userHostIpAddress, out ipAddress))
      {
         string fullNameKey= ipAddress.Country();
         //Or you could use two letter code
         //string twoLetterKey = ipAddress.Iso3166TwoLetterCode();
         if(dict.ContainsKey(theKey)){
              result  = dict[fullNameKey];
         }
      }else{
         result = dict["Default"];
      }
      return result;
    }
 
 
