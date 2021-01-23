    public static bool IsValidIP(string ipAddress)
    {
      IPAddress unused;
      return IPAddress.TryParse(ipAddress, out unused);
    }
