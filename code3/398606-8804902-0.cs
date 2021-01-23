    public class MyController : Controller
    {
        public void Index()
        {
            PropertyBag["includeZeroBalances"] = false;
            PropertyBag["toDate"] = DateTime.Today.ToShortDateString();
        }
        
        public void Download(bool includeZeroBalances, DateTime toDate)
        {
            MyProxy proxy = GetProxy();
            byte[] file = proxy.GetFile(includeZeroBalance, toDate);
            PropertyBag["downloadurl"] = "data:application/zip;base64," + System.Convert.ToBase64String(file);
        }
    }
