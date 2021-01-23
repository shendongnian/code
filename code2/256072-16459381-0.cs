    using System.Web.Helpers;
    
    public static T Clone<T>(T source)
    {
        return Json.Decode<T>(Json.Encode(source));        
    }
