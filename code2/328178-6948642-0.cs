    int cacheValue;
    string cacheValueAsString = ConfigurationManager.AppSettings["slidingExpirationInMinutes"];
    if(int.TryParse(cacheValueAsString, out cacheValue)
    {
       //Set the value here
    }
    else
    {
       //Fallback to default?
    }
