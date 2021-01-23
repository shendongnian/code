    var result = from p in ListofModel
                 group p by p.ClientNo into g
                 orderby g.Key.Date
                select new ModelClass
                {
                 ClientNo = g.Key.ClientNo,
                 Name = g.Key.Name,               
                 Date = g.Key.Date,
                 Time = g.SUM(t => t.Time)                  
                }
