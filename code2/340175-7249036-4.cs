    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class GridTestService : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod]
        public string GetData(GridSettings grid)
        {
            var query = new FakeComputersRepository().Computers();
            var response = grid.SerializeQuery(query, d => new List<string>
            {
                d.ID.ToString(),
                d.IsOnline.ToString(),
                d.Name,
                d.IP,
                d.User
            });
            return response;
        }
    }
