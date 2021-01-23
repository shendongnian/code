    public class Helper
    {
        public int id { get; set; }
        public int islem { get; set; }
        public string textx { get; set; }
        // ...
    }
    using (SerasMacEntity SME = new SerasMacEntity())
    {
        var SQL = (from p in SME.tbl_admin_islem
                   orderby p.tarih descending
                   select new Helper
                   {
                      id = p.id,
                      islem = p.islem,
                      //...
                   });
        var list = SQL.ToList(); // excutes query in DB, rest happens in memory
        foreach (var item in list)
        {
            item.testx = D.Where(x => x.Key == item.islem)
                          .Select(x => x.Value)
                          .FirstOrDefault();
        }
        Store1.DataSource = list;
        Store1.DataBind();
    }
