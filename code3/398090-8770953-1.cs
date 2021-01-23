    public partial class _Foo : System.Web.UI.Page
    {
        [WebMethod]
        public static string SavePerson(Person p)
        {
            // do some processing with the person
            return "Hello World";
        }
    }
