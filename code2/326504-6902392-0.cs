        public static String ConvertServerToClientAdapter(String adapterServer)
    {
        
        switch (adapterServer.Substring(0, adapterServer.IndexOf("/")))
        {
            case "f":
                {
                    return "FA";
                }
            case "g":
                {
                    return "Gi";
                }
            case "s":
                {
                    return "SE";
                }
            case "a":
                {
                    return "ATM";
                }
            default:
               {
                 switch (adapterClient)
    {
        case "FA":
            {
                return "f";
            }
        case "Gi":
            {
                return "g";
            }
        case "SE":
            {
                return "s";
            }
        case "ATM":
            {
                return "a";
            }
        default:
            return null;
    }
     }
          }
         }
