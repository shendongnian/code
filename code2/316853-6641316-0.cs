    public partial class _Default : Page 
    {
        [WebMethod]
        public static SomeObject GetObject()
        {
            SomeObject result = ... fetch from db or something
            return result;
        }
    }
