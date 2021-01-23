    public partial class Products : System.Web.UI.Page 
    { 
        [System.Web.Services.WebMethod()] 
        [System.Web.Script.Services.ScriptMethod()] 
        public static List<Product> GetProducts(int cateogryID) 
        {
            // Put your logic here to get the Product list 
        }
