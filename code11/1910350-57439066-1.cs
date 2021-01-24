    DateTime fechaInicial=  new DateTime(2019, 7, 1, 17, 0, 0);
    DateTime fechaFinal=  new DateTime(2019, 7, 1, 17, 0, 0);
    string canal = "channel";
     var result = (from cat in ctx.CATEGORIAS
                    where cat.sm_canal  == canal && cat.sm_fecha >= fechaInicial && cat.sm_fecha <= fechaFinal
                    group cat  by cat.sm_categoria  into g
                          select new YourCustomClass { 
                                      sm_categoria= g.Key, 
                                      Facebook = g.Where(p=> p.sm_red  =="Facebook").Count(),
                                      Twitter = g.Where(p=> p.sm_red  =="Twitter").Count(),
                                      Instagram = g.Where(p=> p.sm_red  =="Instagram").Count()
                                      }).ToList();
    public class YourCustomClass {
        public string  sm_categoria { get; set; }
        public int Facebook { get; set; }
        public int Twitter { get; set; }
        public int Instagram { get; set; }
    }
