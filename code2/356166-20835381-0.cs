    using System.Web;
    
    [assembly: PreApplicationStartMethod(typeof(ClassLibrary.Startup), "Start")]
    
    namespace ClassLibrary
    {
        public class Startup
        {
            public static void Start()
            {
                // do some awesome stuff here!
            }
        }
    }
