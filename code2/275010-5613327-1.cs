    public partial class _Default : Page 
    {
        [WebMethod]
        public static string Process(Person person)
        {
             // TODO: do some processing
             return DateTime.Now.ToString();
        }
        ...
    }
