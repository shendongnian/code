    var result = (from c in List<EntityFrameworkClass> 
                 select new { 
                            PropertyINeedOne=c.EntityFrameworkClassProperty1,
                            PropertyINeedTwo=c.EntityFrameworkClassProperty2
                  }).ToList();
