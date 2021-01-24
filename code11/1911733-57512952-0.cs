        class Program
        {
            static void Main(string[] args)
            {
                DataBase db = new DataBase();
                var results = (from m in db.masters
                               join c in db.children on m._id equals c._id
                               join d in db.details on m._id equals d._id
                               select new { master = m, child = c, details = d })
                               .GroupBy(x => x.master._id)
                               .Select(x => new
                               {
                                   name = x.First().master.Name,
                                   description = x.First().details.Description,
                                   children = x.Select(y => new { childName = y.child.Name, sharedCode = y.child.SharedCode }).ToArray()
                               }).ToArray();
            }
        }
        public class DataBase
        {
            public List<Master> masters { get; set; }
            public List<Child> children { get; set; }
            public List<Details> details { get; set; }
        }
        public class Master
        {
            public int _id { get; set;}
            public string SharedCode  { set; get;}
            public string Name {get;set;}
            public string Child { get; set; }  
        }
        public class Child
        {
            public int _id { get; set; }
            public string SharedCode { set; get; }
            public string Name { get; set; }
        }
        public class Details
        {
            public int _id { get; set; }
            public string SharedCode { set; get; }
            public string Description { get; set; }
        }
