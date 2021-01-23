    public class YourPage : Page
    {
        [WebMethod]
        public static object GetData() {
            // return your data here
            return new {Data1 = ..., Data2 = ...};
        }
    }
