    public class tabledetail
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string detail { get; set; }
    }
    var q = db.Query<tabledetail>(
            "select c.Id,c.name,a.detail from Active a"
        + " inner join Classes c"
        + " on c.idAc = a._id").ToList();
            return q.Select(x => new tabledetail
            { Id = x.Id, name = x.name ,detail=x.detail }).ToList();
