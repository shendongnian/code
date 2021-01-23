    using System.Web;
    public class Test
    {
        public static string getfile(HttpServerUtility Server )
        {
            return Server.MapPath("~/Default.aspx");
        }
    }
