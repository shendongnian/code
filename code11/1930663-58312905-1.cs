    using dependencies;
    
    namespace Automata.Controllers
    {
        public class HomeController : Controller
        {
            protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
           {
                //code here
           }
            public System.Data.DataTable dt_PagosRecibidos = new System.Data.DataTable();
            public ActionResult PagosRecibidos()
            {
                cargarPagosRecibidos();
                return View();
            }
            public void cargarPagosRecibidos()
            {
                string myVar = "";
                String SentaiAppServer = System.Configuration.ConfigurationManager.AppSettings["SentaiAppServer"].ToString();
                string sURL = SentaiAppServer + ("app/interfaces/bbva/sp_EstadoCuenta.html?fecha_ini=07/16/19&fecha_fin=07/16/19&interfazado=no&Sucursal=" + myVar + "&");
                System.Data.DataSet ds = clsUtilerias.ObtenerDSInterfaceSentai(sURL);
                dt_PagosRecibidos = ds.Tables[1];
            }
        }
    }
